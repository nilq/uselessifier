require("lovekit/all")
require("os")
local g
g = love.graphics
g.setBackgroundColor(71, 166, 71)
g.setDefaultFilter("nearest", "nearest")
local Useless
do
  local _class_0
  local _base_0 = {
    add_method = function(self, cmd, title, img)
      self.methods[#self.methods + 1] = {
        cmd = cmd,
        title = title,
        img = img
      }
    end,
    draw = function(self)
      g.setColor(255, 255, 255)
      g.draw(self.logo, g.getWidth() / 2, 100, self.pot_rot, 4, 4, self.logo:getWidth() / 2, self.logo:getHeight() / 2)
      for n = 1, #self.methods do
        local m = self.methods[n]
        if n ~= self.selected then
          g.setColor(180, 180, 180)
          g.rectangle("fill", g.getWidth() / 4, n * 32 + g.getHeight() / 3 + 16, g.getWidth() / 2, 24)
        else
          g.setColor(210, 210, 210)
          g.rectangle("fill", g.getWidth() / 4 - 16, n * 32 + g.getHeight() / 3 + 16, g.getWidth() / 2 + 32, 24)
        end
        g.setColor(255, 255, 255)
        g.print(m.title, g.getWidth() / 2.1 - 16, n * 32 + g.getHeight() / 2.95 + 16)
        if self.text_prompt then
          g.setColor(210, 210, 210)
          g.rectangle("fill", 0, g.getHeight() / 4, g.getWidth(), 64)
          local text = "[ENTER] show 'data.dat' as " .. self.methods[self.selected].title
          g.setColor(255, 255, 255)
          g.print(text, g.getWidth() / 2.1 - g.getFont():getWidth(text) / 2, g.getHeight() / 4 + 28)
        end
      end
    end,
    update = function(self, dt)
      self.pot_rot = self.pot_rot + dt
      self.key_time = self.key_time + dt
      if love.keyboard.isDown("return") then
        local sel = self.methods[self.selected]
        if sel.img then
          os.execute(sel.cmd .. " " .. self.prompt .. " loader/output.png")
          os.execute("love loader image")
        else
          os.execute(sel.cmd .. " " .. self.prompt .. " loader/output.txt")
          os.execute("love loader")
        end
      end
      if self.key_time >= 0.095 then
        if love.keyboard.isDown("down") then
          self.selected = self.selected + 1
        end
        if love.keyboard.isDown("up") then
          self.selected = self.selected - 1
        end
        if self.selected <= 0 then
          self.selected = #self.methods
        elseif self.selected > #self.methods then
          self.selected = 1
        end
        self.key_time = 0
      end
    end
  }
  _base_0.__index = _base_0
  _class_0 = setmetatable({
    __init = function(self)
      self.logo = g.newImage("res/potato.png")
      self.selected = 1
      self.methods = { }
      self.prompt = "data.dat"
      self.key_time = 0
      self.text_prompt = true
      self.pot_rot = 0
      self:add_method("cargo run fractals", "fractalize", true)
      self:add_method("cargo run shakespeare", "shakespearify")
      self:add_method("cargo run morse", "morsify")
      self:add_method("cargo run image", "imagify", true)
      self:add_method("cargo run website", "(trash) websitify")
      self:add_method("cargo run reverse", "reverse")
      return self:add_method("cargo run hash", "hash [wip]")
    end,
    __base = _base_0,
    __name = "Useless"
  }, {
    __index = _base_0,
    __call = function(cls, ...)
      local _self_0 = setmetatable({}, _base_0)
      cls.__init(_self_0, ...)
      return _self_0
    end
  })
  _base_0.__class = _class_0
  Useless = _class_0
end
love.load = function()
  local dispatch = Dispatcher(Useless("Makefile"))
  return dispatch:bind(love)
end
