require "lovekit/all"
require "os"

{graphics: g} = love

g.setBackgroundColor 71, 166, 71
g.setDefaultFilter "nearest", "nearest"

class Useless
  new: =>
    @logo = g.newImage "res/potato.png"
    @selected = 1

    @methods = {}

    @prompt = "data.dat"

    @key_time = 0
    @text_prompt = true

    @pot_rot = 0

    @add_method "cargo run fractals", "fractalize", true
    @add_method "cargo run shakespeare", "shakespearify"
    @add_method "cargo run morse", "morsify"
    @add_method "cargo run image", "imagify", true
    @add_method "cargo run website", "(trash) websitify"
    @add_method "cargo run reverse", "reverse"
    @add_method "cargo run hash", "hash [wip]"

  add_method: (cmd, title, img) =>
    @methods[#@methods + 1] = {cmd: cmd, title: title, img: img}

  draw: =>

    g.setColor 255, 255, 255
    g.draw @logo, g.getWidth! / 2, 100, @pot_rot, 4, 4, @logo\getWidth! / 2, @logo\getHeight! / 2

    for n = 1, #@methods
      m = @methods[n]
      if n != @selected
        g.setColor 180, 180, 180
        g.rectangle "fill", g.getWidth! / 4, n * 32 + g.getHeight! / 3 + 16, g.getWidth! / 2, 24
      else
        g.setColor 210, 210, 210
        g.rectangle "fill", g.getWidth! / 4 - 16, n * 32 + g.getHeight! / 3 + 16, g.getWidth! / 2 + 32, 24

      g.setColor 255, 255, 255
      g.print m.title, g.getWidth! / 2.1 - 16, n * 32 + g.getHeight! / 2.95 + 16

      if @text_prompt
        g.setColor 210, 210, 210
        g.rectangle "fill", 0, g.getHeight! / 4, g.getWidth!, 64

        text = "[ENTER] show 'data.dat' as " .. @methods[@selected].title

        g.setColor 255, 255, 255
        g.print text, g.getWidth! / 2.1 - g.getFont!\getWidth(text) / 2, g.getHeight! / 4 + 28

  update: (dt) =>
    @pot_rot += dt
    @key_time += dt
    if love.keyboard.isDown "return"
      sel = @methods[@selected]
      if sel.img
        os.execute sel.cmd .. " " .. @prompt .. " loader/output.png"
        os.execute "love loader image"
      else
        os.execute sel.cmd .. " " .. @prompt .. " loader/output.txt"
        os.execute "love loader"
    if @key_time >= 0.095
      if love.keyboard.isDown "down"
        @selected += 1
      if love.keyboard.isDown "up"
        @selected -= 1

      if @selected <= 0
        @selected = #@methods
      elseif @selected > #@methods
        @selected = 1

      @key_time = 0

love.load = ->
  dispatch = Dispatcher Useless "Makefile"
  dispatch\bind love
