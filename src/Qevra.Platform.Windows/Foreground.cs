// Windows lets only the process the user is working with bring a window to the front. A second Qevra started from
// Explorer's menu or Send To has that right and passes the files to the running Qevra; without handing the right on,
// the donut it opens can't take the focus, so Esc and clicking elsewhere don't close it.

namespace Qevra.Platform.Windows;

public static class Foreground
{
    /// <summary>Lets another process (the running Qevra) bring its window to the front. No-op off Windows.</summary>
    public static void AllowOtherProcess()
    {
        if (OperatingSystem.IsWindows())
            NativeMethods.AllowSetForegroundWindow(NativeMethods.ASFW_ANY);
    }
}
