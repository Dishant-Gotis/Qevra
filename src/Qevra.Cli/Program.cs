// Entry point of qevra-cli.exe (run as "qevra" through cli\qevra.cmd). Ctrl+C cancels the running conversion or
// stops watching; a second Ctrl+C ends the process at once.

using System.Text;
using Qevra.Cli;

Console.OutputEncoding = Encoding.UTF8;
using var cancel = new CancellationTokenSource();
Console.CancelKeyPress += (_, e) =>
{
    if (cancel.IsCancellationRequested)
        return;
    e.Cancel = true;
    cancel.Cancel();
};
return await Cli.RunAsync(args, Console.Out, Console.Error, cancel.Token);
