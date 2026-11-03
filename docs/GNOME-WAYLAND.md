# GNOME Wayland

Qevra supports drag gestures on GNOME Wayland through the **Qevra donut at the cursor** GNOME Shell extension.

The extension provides the pointer state required by Qevra without access to `/dev/input`, membership in the `input` group, or running Qevra as root.

> This integration is experimental and has been tested on Fedora 44 with GNOME Shell 50.

## Setup

Install Qevra normally:

```sh
./install.sh
```

On a GNOME session, `install.sh` puts the extension in `~/.local/share/gnome-shell/extensions/qevra-donut@qevra.sh` and asks GNOME to enable it. Then:

1. Open the **Extensions** application.
2. Enable **Qevra donut at the cursor**.
3. Log out and back in if the extension does not appear.
4. Start Qevra and make sure gesture detection is enabled under **Triggers**.

Do not run Qevra with `sudo`.

## Usage

With the default gesture:

1. Open **Files / Nautilus**.
2. Hold **Ctrl** and drag a file.
3. Move the file over the desired format in the Qevra wheel.
4. Release it to start the conversion.

The wheel stays in place while selecting a format.

Pausing Qevra, disabling the gesture or extension, excluding the application, or dropping outside the wheel leaves the normal file-manager behavior unchanged.

Custom modifiers and excluded applications continue to work through Qevra's existing gesture settings.

## Updates

Updating Qevra, in the app or with `./install.sh --upgrade`, also updates the extension when Qevra installed it. GNOME Shell keeps running the version it loaded at login, so log out and back in after an update. If the running extension and Qevra don't match, the **Triggers** page says so.

`install.sh` replaces only an extension folder that Qevra installed. If the folder came from somewhere else, a first install stops and an upgrade leaves it as it is. `uninstall.sh` removes the extension when Qevra installed it.

## Limitations

- GNOME integration is currently experimental.
- GNOME Shell 45–50 are declared as supported, but not every version has been tested.
- Global Tab and mouse-wheel state are not available for switching wheel faces during a drag.
- Global selection shortcuts and hold gestures are not available.
- Qevra runs through XWayland by default. With the experimental native Wayland backend (`QEVRA_USE_WAYLAND=1`), the extension recognizes the donut by Qevra's process; this combination has had less testing.
- Multi-monitor setups and fractional scaling may require additional testing.

KDE Plasma and Hyprland use a different setup; see `INSTALL.txt`.

## Troubleshooting

If the wheel does not appear:

- Make sure Qevra is not paused.
- Check that the drag gesture is enabled under **Triggers**.
- Make sure **Qevra donut at the cursor** is enabled.
- Make sure Files / Nautilus is not excluded.
- Do not run Qevra with `sudo`.
- If the extension was installed or updated recently, log out and back in.

To check the extension:

```sh
gnome-extensions info qevra-donut@qevra.sh
```

To check the communication socket:

```sh
ls -l "$XDG_RUNTIME_DIR/qevra-gnome/pointer.sock"
```

When connected successfully, Qevra's log (`~/.config/Qevra/logs/`) contains:

```text
GNOME pointer extension connected
```

If the **Triggers** page says the extension belongs to another version of Qevra, log out and back in so GNOME Shell loads the installed extension. If the message stays, reinstall Qevra.
