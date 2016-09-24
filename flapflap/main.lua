require "lib"

love.graphics.setDefaultFilter("nearest", "nearest")

SCALE = 1.75
DEAD  = false

-- math
math.clamp = function(n, a, b)
  if n < a then
    return a
  elseif n > b then
    return b
  end
  return n
end

class: Bird("Transform2D") {
  gravity = 1000;
  jump_height = 300;

  sprite = love.graphics.newImage "res/bird.png";

  dy = 0;

  dead = false;

  update = function(dt)
    if self.dead then
      return
    end

    self.dy = self.dy + self.gravity * dt
    self.translate(0, dy * dt)

    if self.position.y + self.sprite:getHeight() / 2 >= 392 then
      self.dead = true
    end

    self.position.y = math.clamp(self.position.y, self.sprite:getHeight() / 2, love.graphics.getHeight())
  end;

  jump = function()
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

  backgrounds = {};
  grounds = {};

  awake = function()
    self.bird = new: Bird({x = 100, y = 100,})

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

    -- ground

    for k, g in pairs(self.grounds) do
      love.graphics.draw(self.ground, g.x, g.y, 0, SCALE, SCALE)
    end

    -- bird

    love.graphics.draw(self.bird.sprite, self.bird.position.x, self.bird.position.y, self.bird.dy / 800,
        SCALE, SCALE, self.bird.sprite:getWidth() / 2, self.bird.sprite:getHeight() / 2)
  end;
}

local env  = new: Environment()
