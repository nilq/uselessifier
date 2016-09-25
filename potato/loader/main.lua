love.graphics.setDefaultFilter("nearest", "nearest")
love.graphics.setBackgroundColor(255, 255, 255)

function love.load()
  image = false
  if arg[2] == "image" then
    image = true
    output = love.graphics.newImage("output.png")
  else
    lines = {}
    text = {}
    timer = 1
    i = 1
    shown_lines = 100
    for line in io.lines("output.txt") do
      if #lines > 1000 then break end
      lines[#lines + 1] = line
    end
  end
end

function love.update(dt)
  if not image then
    timer = timer - dt
    if timer <= 0 then
      i = i + 1
      timer = 1
    end
  end
end

function love.draw()
  if image then
    local sx, sy = love.graphics.getWidth() / output:getWidth(), love.graphics.getHeight() / output:getHeight()
    love.graphics.draw(output, 0, 0, 0, sx, sy)
  else
    for n = 1, #lines do
      love.graphics.setColor(0,0,0, 255 - (n-1) * 6)
      love.graphics.printf(lines[n], 10, 10, love.graphics.getWidth(), "left")
    end
  end
end
