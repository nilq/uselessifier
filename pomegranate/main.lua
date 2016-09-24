require("lovekit/all")
local _ = {
  graphics = g
}
local Useless
do
  local _class_0
  local _base_0 = { }
  _base_0.__index = _base_0
  _class_0 = setmetatable({
    __init = function(self, path)
      local f = io.open(path, "rb")
      if f({
        f = close()
      }) then
        for l in io.lines(path) do
          print(l)
        end
      else
        return error("Trying to open invalid file!")
      end
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
return love.load(function()
  local dispatch = Dispatcher(Useless)
  return dispatch:bind(love)
end)
