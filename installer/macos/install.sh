#!/bin/sh
set -eu

source_dir=$(CDPATH= cd -- "$(dirname -- "$0")" && pwd -P)
install_dir="$HOME/Applications/Qevra.app"
bin_dir="$HOME/.local/bin"
if [ -e "$install_dir" ] || [ -L "$install_dir" ]; then
    printf '%s\n' "An installation already exists at $install_dir. Run uninstall.sh first."
    exit 1
fi
# A qevra link left by an earlier Qevra whose app is gone (moved to the Trash instead of uninstall.sh) is replaced.
# Anything else at that path isn't ours and stays.
stale_link=false
if [ -L "$bin_dir/qevra" ] && [ ! -e "$bin_dir/qevra" ]; then
    case $(readlink "$bin_dir/qevra") in
        */Qevra.app/Contents/MacOS/qevra-cli) stale_link=true ;;
    esac
fi
if [ "$stale_link" = false ] && { [ -e "$bin_dir/qevra" ] || [ -L "$bin_dir/qevra" ]; }; then
    printf '%s\n' "$bin_dir/qevra already exists. Remove or rename it before installing Qevra."
    exit 1
fi
test -x "$source_dir/Qevra.app/Contents/MacOS/Qevra"
mkdir -p "$HOME/Applications" "$bin_dir"
/usr/bin/ditto "$source_dir/Qevra.app" "$install_dir"
# ditto keeps the download's quarantine flag: macOS would then start Qevra from a translocated copy and could stop
# the qevra command without a word (#316).
/usr/bin/xattr -dr com.apple.quarantine "$install_dir" 2>/dev/null || true
if [ "$stale_link" = true ]; then
    rm -f -- "$bin_dir/qevra"
    printf '%s\n' "Replaced the qevra link left by an earlier installation."
fi
ln -s "$install_dir/Contents/MacOS/qevra-cli" "$bin_dir/qevra"
printf '%s\n' "Installed $install_dir" "CLI: $bin_dir/qevra (add $bin_dir to PATH if needed)."
printf '%s\n' 'Open Qevra from Applications. Grant Accessibility and Finder Automation access when requested.'
printf '%s\n' 'If Qevra is already listed and switched on under Accessibility, remove it with the - button and add it again with +.'
