#        _   _ _
#   __ _| |_(_) | ___
#  / _` | __| | |/ _ \
# | (_| | |_| | |  __/
#  \__, |\__|_|_|\___|
#     |_|
#


from typing import List  # noqa: F401
from libqtile import bar, layout, widget
from libqtile.config import Click, Drag, Group, Key, KeyChord, Match, Rule, Screen
from libqtile.lazy import lazy
from libqtile.utils import guess_terminal
from libqtile.log_utils import logger
from unicodes import right_arrow, left_arrow, lower_left_triangle, left_half_circle, right_half_circle
import os
import subprocess

from libqtile import hook

mod = "mod4"
terminal = "alacritty"

keys = [
    # A list of available commands that can be bound to keys can be found
    # at https://docs.qtile.org/en/latest/manual/config/lazy.html
    # Switch between windows
    Key([mod], "h", lazy.layout.left(), desc="Move focus to left"),
    Key([mod], "l", lazy.layout.right(), desc="Move focus to right"),
    Key([mod], "j", lazy.layout.down(), desc="Move focus down"),
    Key([mod], "k", lazy.layout.up(), desc="Move focus up"),
    # Move windows between left/right columns or move up/down in current stack.
    # Moving out of range in Columns layout will create new column.
    Key(
        [mod, "shift"], "h", lazy.layout.shuffle_left(), desc="Move window to the left"
    ),
    Key(
        [mod, "shift"],
        "l",
        lazy.layout.shuffle_right(),
        desc="Move window to the right",
    ),
    Key([mod, "shift"], "j", lazy.layout.shuffle_down(), desc="Move window down"),
    Key(
        [mod, "shift"],
        "k",
        lazy.layout.shuffle_up(),
        desc="Move window up",
    ),
    Key([mod, "control"], "j", lazy.layout.shrink(), desc="Grow window down"),
    Key([mod, "control"], "k", lazy.layout.grow(), desc="Grow window up"),
    # Toggle between split and unsplit sides of stack.
    # Split = all windows displayed
    # Unsplit = 1 window displayed, like Max layout, but still with
    # multiple stack panes
    Key(
        [mod, "shift"],
        "Return",
        lazy.layout.toggle_split(),
        desc="Toggle between split and unsplit sides of stack",
    ),
    Key([mod], "Return", lazy.spawn(terminal), desc="Launch terminal"),
    # Toggle between different layouts as defined below
    Key([mod], "space", lazy.next_layout(), desc="Toggle between layouts"),
    Key([mod], "q", lazy.window.kill(), desc="Kill focused window"),
    Key([mod], "n", lazy.layout.reset(), desc="reset size"),
    Key([mod, "control"], "r", lazy.reload_config(), desc="Reload the config"),
    Key([mod, "control"], "q", lazy.shutdown(), desc="Shutdown Qtile"),
    Key(
        [mod],
        "f",
        lazy.window.toggle_floating(),
        desc="toggle between floating and non floating",
    ),
    Key([mod], "d", lazy.spawn("rofi -show drun")),
    Key([mod], "g", lazy.spawn("i3lock")),
    # Key([mod], "d", lazy.spawncmd(), desc="Spawn a command using a prompt widget"),
    # Sound
    Key([], "XF86AudioMute", lazy.spawn("amixer -q set Master toggle")),
    Key([], "XF86AudioLowerVolume", lazy.spawn(
        "amixer -c 0 sset Master 2- unmute")),
    Key([], "XF86AudioRaiseVolume", lazy.spawn(
        "amixer -c 0 sset Master 2+ unmute")),
]

groups = [Group(i) for i in "123456789"]

for i in groups:
    keys.extend(
        [
            # mod1 + letter of group = switch to group
            Key(
                [mod],
                i.name,
                lazy.group[i.name].toscreen(),
                desc="Switch to group {}".format(i.name),
            ),
            # mod1 + shift + letter of group = switch to & move focused window to group
            Key(
                [mod, "shift"],
                i.name,
                lazy.window.togroup(i.name, switch_group=True),
                desc="Switch to & move focused window to group {}".format(
                    i.name),
            ),
            Key(
                [mod],
                "o",
                lazy.screen.next_group(),
            ),
            Key(
                [mod],
                "i",
                lazy.screen.prev_group(),
            ),
            # Or, use below if you prefer not to switch to that group.
            # # mod1 + shift + letter of group = move focused window to group
            # Key([mod, "shift"], i.name, lazy.window.togroup(i.name),
            #     desc="move focused window to group {}".format(i.name)),
        ]
    )

layouts = [
    # layout.Columns(
    #     border_focus="#D08770",
    #     border_normal="#5E81AC",
    #     border_width=3,
    #     margin=8,
    #     border_on_single=True,
    # ),
    layout.MonadTall(
        border_focus="#D08770",
        border_normal="#5E81AC",
        border_width=3,
        margin=10,
        border_on_single=True,
    ),
    # layout.Floating(
    #     border_focus="#D08770",
    #     border_normal="#5E81AC",
    #     border_width=3,
    # ),
]

nord = {
    "nord0": "#2E3440",  # dark colors
    "nord1": "#3B4252",
    "nord2": "#434C5E",
    "nord3": "#4C566A",
    "nord4": "#D8DEE9",  # light colors
    "nord5": "#E5E9F0",
    "nord6": "#ECEFF4",
    "nord7": "#8FBCBB",  # frost(greens and blues)
    "nord8": "#88C0D0",
    "nord9": "#81A1C1",
    "nord10": "#5E81AC",
    "nord11": "#BF616A",  # aurora(rainbow color)
    "nord12": "#D08770",
    "nord13": "#EBCB8B",
    "nord14": "#A3BE8C",
    "nord15": "#B48EAD",
}

widget_defaults = dict(
    font="JetBrainsMonoMedium Nerd Font",
    fontsize=16,
    padding=5,
    background=nord["nord1"],
    foreground=nord["nord4"],
)
extension_defaults = widget_defaults.copy()


screens = [
    Screen(
        top=bar.Bar(
            [
                widget.GroupBox(
                    inactive="5E81AC",
                    active="#ECEFF4",
                    highlight_method="line",
                    highlight_color=["#4c566a"],
                    padding_x=13,
                    this_current_screen_border="#88C0D0",
                ),

                widget.WindowName(max_chars=50),
                left_half_circle(nord["nord15"]),
                widget.PulseVolume(
                    fmt="奔{}",
                    background=nord["nord15"],
                    mouse_callbacks={
                        "Button1": lazy.spawn("pavucontrol"),
                    },
                ),
                right_half_circle(nord["nord15"]),

                widget.Spacer(length=10),
                left_half_circle(nord["nord7"]),
                widget.KeyboardLayout(
                    configured_keyboards=["us", "ca"], fmt=" {}", background=nord["nord7"]
                ),
                right_half_circle(nord["nord7"]),
                widget.Spacer(length=10),
                left_half_circle(nord["nord8"]),
                widget.CPU(
                    format=" {load_percent}%",
                    background=nord["nord8"],
                    mouse_callbacks={
                        "Button1": lazy.spawn("alacritty --class htop -e htop"),
                    },
                ),
                right_half_circle(nord["nord8"]),
                widget.Spacer(length=10),
                left_half_circle(nord["nord9"]),
                widget.Memory(
                    fmt="{}",
                    background=nord["nord9"],
                    mouse_callbacks={
                        "Button1": lazy.spawn("alacritty --class htop -e htop"),
                    },
                ),
                right_half_circle(nord["nord9"]),
                widget.Spacer(length=10),
                left_half_circle(nord["nord10"]),
                widget.Clock(format=" %Y-%m-%d %a %I:%M %p",
                             background=nord["nord10"]),
                right_half_circle(nord["nord10"]),
                widget.Spacer(length=10),
                left_half_circle(nord["nord14"]),
                widget.Systray(background=nord["nord14"]),
                widget.TextBox(background=nord["nord14"], fmt=' '),
            ],
            size=30,
            border_color=[
                "ff00ff",
                "000000",
                "ff00ff",
                "000000",
            ],  # Borders are magenta
        ),
    ),
]


# Drag floating layouts.
mouse = [
    Drag(
        [mod],
        "Button1",
        lazy.window.set_position_floating(),
        start=lazy.window.get_position(),
    ),
    Drag(
        [mod], "Button3", lazy.window.set_size_floating(), start=lazy.window.get_size()
    ),
    Click([mod], "Button2", lazy.window.bring_to_front()),
]

dgroups_key_binder = None
dgroups_app_rules = []  # type: List
follow_mouse_focus = True
bring_front_click = False
cursor_warp = False

floating_layout = layout.Floating(
    float_rules=[
        # Run the utility of `xprop` to see the wm class and name of an X client.
        *layout.Floating.default_float_rules,
        Match(wm_class="confirmreset"),  # gitk
        Match(wm_class="makebranch"),  # gitk
        Match(wm_class="maketag"),  # gitk
        Match(wm_class="htop"),  # gitk
        Match(title="Volume Control"),  # gitk
        Match(wm_class="ssh-askpass"),  # ssh-askpass
        Match(wm_class="update"),  # ssh-askpass
        Match(wm_class="Godot_Engine", title="DEBUG"),  # ssh-askpass
        Match(wm_class="edit-config"),  # ssh-askpass
        Match(title="branchdialog"),  # gitk
        Match(title="pinentry"),  # GPG key password entry
    ],
    border_focus="#D08770",
    border_normal="#5E81AC",
    border_width=3,
)
auto_fullscreen = True
focus_on_window_activation = "smart"
reconfigure_screens = True

# If things like steam games want to auto-minimize themselves when losing
# focus, should we respect this or not?
auto_minimize = True

# XXX: Gasp! We're lying here. In fact, nobody really uses or cares about this
# string besides java UI toolkits; you can see several discussions on the
# mailing lists, GitHub issues, and other WM documentation that suggest setting
# this string if your java app doesn't work correctly. We may as well just lie
# and say that we're a working one by default.
#
# We choose LG3D to maximize irony: it is a 3D non-reparenting WM written in
# java that happens to be on java's whitelist.
wmname = "LG3D"


@hook.subscribe.startup_once
def autostart():
    home = os.path.expanduser("~/.config/qtile/autostart.sh")
    subprocess.run([home])
