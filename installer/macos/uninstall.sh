#!/bin/sh
set -eu

install_dir="$HOME/Applications/Qevra.app"
if [ -L "$install_dir" ] || [ ! -d "$install_dir" ]; then
    printf '%s\n' "No ordinary Qevra app bundle was found at $install_dir."
    exit 1
fi
resolved_parent=$(CDPATH= cd -- "$HOME/Applications" && pwd -P)
resolved_app=$(CDPATH= cd -- "$install_dir" && pwd -P)
if [ "$resolved_app" != "$resolved_parent/Qevra.app" ]; then
    printf '%s\n' 'Refusing to remove an app outside the expected Applications directory.'
    exit 1
fi
bundle_id=$(/usr/libexec/PlistBuddy -c 'Print :CFBundleIdentifier' "$install_dir/Contents/Info.plist")
if [ "$bundle_id" != 'com.qevra.app' ]; then
    printf '%s\n' 'The bundle is not Qevra.'
    exit 1
fi
"$install_dir/Contents/MacOS/Qevra" --uninstall-cleanup
if [ -L "$HOME/.local/bin/qevra" ] && [ "$(readlink "$HOME/.local/bin/qevra")" = "$install_dir/Contents/MacOS/qevra-cli" ]; then
    rm -- "$HOME/.local/bin/qevra"
fi
rm -rf -- "$install_dir"
printf '%s\n' 'Qevra was removed. Your settings and conversion results were kept.'
