require "lib"

love.graphics.setDefaultFilter("nearest", "nearest")

-- sounds
flap  = love.audio.newSource("res/flap.ogg", "static");
death = love.audio.newSource("res/die.ogg", "static");
hit   = love.audio.newSource("res/hit.ogg", "static");

hit:setVolume(0.5)
-- end of sounds

SCALE = 1.75
DATA = "res/shakespeare.txt"

love.window.setTitle(DATA)

-- byte map
file = assert(io.open(DATA, "rb"))
block = 1

bytes = {}

while true do
  local byte = file:read(block)
  if byte then
    bytes[#bytes + 1] = string.byte(byte)
  else
    break
  end
end

file:close()
-- end of byte map

-- math
math.clamp = function(n, a, b)
  if n < a then
    return a
  elseif n > b then
    return b
  end
  return n
end

math.intersect = function(x1,y1,w1,h1, x2,y2,w2,h2)
  return x1 < x2+w2 and
         x2 < x1+w1 and
         y1 < y2+h2 and
         y2 < y1+h1
end

math.sign = function(n)
  if n > 0 then
    return 1
  elseif n < 0 then
    return -1
  end
  return 0
end
-- not math

get_height_byte = function(n)
  if n % 2 == 0 then
    return bytes[n] * -0.15
  end

  return bytes[n]
end

class: Bird("Transform2D") {
  gravity = 1000;
  jump_height = 300;

  sprite = love.graphics.newImage "res/bird.png";

  dy = 0;

  dead = false;

  die = function(dt)
    death:play()
    self.dead = true
  end;

  update = function(dt)
    if self.dead then
      return
    end

    self.dy = self.dy + self.gravity * dt
    self.translate(0, dy * dt)

    if self.position.y + self.sprite:getHeight() * SCALE - 8 >= 392 then
      hit:play()
      self:die()
    end

    for k, v in pairs(self.pipes) do
      if math.intersect(self.position.x, self.position.y, self.sprite:getWidth() / 1.25 * SCALE, self.sprite:getHeight() / 1.25 * SCALE,
          v.x, v.y, self.pipe:getWidth() * SCALE, self.pipe:getHeight() * SCALE) then
        hit:play()
        self:die()
      end
    end

    self.position.y = math.clamp(self.position.y, self.sprite:getHeight() / 2, love.graphics.getHeight())
  end;

  jump = function()
    flap:play()
    dy = -self.jump_height
  end;

  keychanged = function(key, state)
    if key == "space" and state then
      self:jump()
    end
  end;
}

class: Environment() {
  background = love.graphics.newImage "res/background.png";
  ground = love.graphics.newImage "res/ground.png";
  game_over = love.graphics.newImage "res/gameover.png";
  pipe = love.graphics.newImage "res/pipe.png";

  backgrounds = {};
  grounds = {};
  pipes = {};

  that_nice_music = love.audio.newSource("res/thomas.mp3");

  awake = function()
    self.that_nice_music:setVolume(1);

    local a = self.ground:getWidth() * SCALE

    for n = 0, love.graphics.getWidth() / a + 4 do
      table.insert(self.grounds, {
        x = n * a - n, y = love.graphics.getHeight() - self.ground:getHeight(),
      })
    end

    for n = 0, 4 do
      table.insert(self.backgrounds, {
        x = self.background:getWidth() * n * SCALE - n * 4, y = 0,
      })
    end

    for n = 1, 4 do
      table.insert(self.pipes, {
        x = 100 + self.pipe:getWidth() * n * 3.2 * SCALE, y = -self.pipe:getHeight()
            * SCALE / 2.35 + get_height_byte(n), a = n,
      })

      table.insert(self.pipes, {
        x = 100 + self.pipe:getWidth() * n * 3.2 * SCALE, y = love.graphics.getHeight()
            - self.pipe:getHeight() * SCALE + get_height_byte(n), a = n,
      })
    end

    self.bird = new: Bird({x = 100, y = 200,})
    self.bird.pipes = self.pipes
    self.bird.pipe  = self.pipe

    self.that_nice_music:play()
  end;

  keychanged = function(key, state)
    if self.bird.dead then
      self.that_nice_music:rewind()
      kill_these({self.bird})

      reset()
    end
  end;

  update = function(dt)

    if self.bird.dead then
      return
    end

    for k, g in pairs(self.grounds) do
      g.x = g.x - dt * 100
      if g.x < 0 - self.ground:getWidth() - 5 then
        g.x = love.graphics.getWidth()
      end
    end

    for k, g in pairs(self.pipes) do
      g.x = g.x - dt * 100
      if g.x < 0 - self.pipe:getWidth() * SCALE * 1.25 then
        g.x = love.graphics.getWidth() + self.pipe:getWidth() * SCALE * 1.25
        g.a = g.a + 1
        g.y = g.y + get_height_byte(g.a)
      end
    end

    for k, g in pairs(self.backgrounds) do
      g.x = g.x - dt * 50
      if g.x < 0 - self.background:getWidth() * 2 - 4 then
        g.x = love.graphics.getWidth()
      end
    end
  end;

  draw = function()
    for k, g in pairs(self.backgrounds) do
      love.graphics.draw(self.background, g.x, g.y, 0, SCALE, SCALE)
    end

    -- pipe
    for k, g in pairs(self.pipes) do
      love.graphics.draw(self.pipe, g.x, g.y, 0, SCALE, SCALE)
    end

    -- ground
    for k, g in pairs(self.grounds) do
      love.graphics.draw(self.ground, g.x, g.y, 0, SCALE, SCALE)
    end

    -- bird
    love.graphics.draw(self.bird.sprite, self.bird.position.x, self.bird.position.y, self.bird.dy / 800,
        SCALE, SCALE, self.bird.sprite:getWidth() / 2, self.bird.sprite:getHeight() / 2)

    -- game over
    if self.bird.dead then
      love.graphics.draw(self.game_over, love.graphics.getWidth() / 2 - self.game_over:getWidth() * SCALE * 2 / 2,
          love.graphics.getHeight() / 2 - self.game_over:getHeight() * SCALE * 2, 0, SCALE * 2, SCALE * 2)
    end
  end;
}

env = new: Environment()

function reset()
  kill_these({env})
  env = new: Environment()
end
