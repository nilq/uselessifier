require "lovekit/all"

{graphics: g}

class Useless
  new: (path) =>
    f = io.open(path, "rb")
    if f
      f:close()
      for l in io.lines(path)
        print l
    else
      error "Trying to open invalid file!"

love.load ->
  dispatch = Dispatcher Useless
  dispatch\bind love
