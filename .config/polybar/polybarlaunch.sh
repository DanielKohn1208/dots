#! bin/sh

# Terminal already running bar intances 
killall -q polybar

# wait until the process have been hsut don
while pgrep -u $UID -x polybar >/dev/null; do sleep 1; done

# launch bar
polybar example &


