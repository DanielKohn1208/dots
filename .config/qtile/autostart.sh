#!/bin/sh
xrandr --output HDMI-0  --mode 2560x1080 --rate 75.00 &
feh --bg-fill $HOME/wallpaper/nord-city.jpg &
picom -b&
dunst &
nm-applet &
