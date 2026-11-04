// Drop zone: files dropped on the Home page open the flower menu (click mode) at the drop position, also pictures, links and

// downloads dragged from a browser. Quick action buttons trigger file picking, clipboard paste, or instant flower testing.



using Avalonia;

using Avalonia.Controls;

using Avalonia.Input;

using Avalonia.Interactivity;

using Avalonia.Platform.Storage;

using Qevra.App.Services;

using Qevra.Core.Platform;

using Microsoft.Extensions.Logging;



namespace Qevra.App.Views.Pages;



public partial class HomePage : UserControl

{

    private static int _dragEnterLogged;



    public HomePage()

    {

        InitializeComponent();

        DropZone.DoubleTapped += OnDropZoneDoubleTapped;

        SelectFilesButton.Click += OnSelectFilesClicked;

        PasteClipboardButton.Click += OnPasteClipboardClicked;

        TestFlowerRingButton.Click += OnTestFlowerRingClicked;



        DragDrop.AddDragEnterHandler(DropZone, (_, e) =>

        {

            DropZone.Classes.Add("over");

            var files = DraggedFiles.Offered(e.DataTransfer);

            e.DragEffects = files ? DragDropEffects.Copy : DragDropEffects.None;

            if (Interlocked.Exchange(ref _dragEnterLogged, 1) == 0)

                AppHost.Get<ILogger<HomePage>>().LogInformation("First drag over the drop zone (files: {Files})", files);

        });

        DragDrop.AddDragOverHandler(DropZone, (_, e) =>

            e.DragEffects = DraggedFiles.Offered(e.DataTransfer) ? DragDropEffects.Copy : DragDropEffects.None);

        DragDrop.AddDragLeaveHandler(DropZone, (_, _) => DropZone.Classes.Remove("over"));

        DragDrop.AddDropHandler(DropZone, OnDrop);

    }



    private async void OnSelectFilesClicked(object? sender, RoutedEventArgs e)

    {

        if (TopLevel.GetTopLevel(this) is not { } top)

            return;



        var files = await top.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions { AllowMultiple = true });

        var paths = files

            .Select(f => f.TryGetLocalPath())

            .Where(p => !string.IsNullOrEmpty(p))

            .Select(p => p!)

            .ToList();



        if (paths.Count == 0)

            return;



        var targetPos = new Point(DropZone.Bounds.Width / 2, DropZone.Bounds.Height / 2);

        var screenPoint = DropZone.PointToScreen(targetPos);

        AppHost.Get<RadialController>().ShowForFiles(screenPoint.X, screenPoint.Y, paths);

    }



    private void OnPasteClipboardClicked(object? sender, RoutedEventArgs e)
    {
        var targetPos = new Point(DropZone.Bounds.Width / 2, DropZone.Bounds.Height / 2);
        var screenPoint = DropZone.PointToScreen(targetPos);
        App.ShowForClipboard(AppHost.Get<RadialController>(), AppHost.Get<IPlatformServices>(),
            screenPoint.X, screenPoint.Y, AppHost.Get<ILogger<HomePage>>());
    }

    private void OnTestFlowerRingClicked(object? sender, RoutedEventArgs e)

    {

        var targetPos = new Point(DropZone.Bounds.Width / 2, DropZone.Bounds.Height / 2);

        var screenPoint = DropZone.PointToScreen(targetPos);

        var sampleFile = Path.Combine(AppContext.BaseDirectory, "Assets", "Icons", "qevra.png");

        if (!File.Exists(sampleFile))

        {

            var files = Directory.GetFiles(AppContext.BaseDirectory, "*.dll");

            sampleFile = files.Length > 0 ? files[0] : AppContext.BaseDirectory;

        }

        AppHost.Get<RadialController>().ShowForFiles(screenPoint.X, screenPoint.Y, [sampleFile]);

    }



    private async void OnDropZoneDoubleTapped(object? sender, TappedEventArgs e)

    {

        e.Handled = true;

        if (TopLevel.GetTopLevel(this) is not { } top)

            return;



        var files = await top.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions { AllowMultiple = true });



        var paths = files

            .Select(f => f.TryGetLocalPath())

            .Where(p => !string.IsNullOrEmpty(p))

            .Select(p => p!)

            .ToList();



        if (paths.Count == 0)

            return;



        var dropZonePos = e.GetPosition(DropZone);

        var targetPos = new Rect(0, 0, DropZone.Bounds.Width, DropZone.Bounds.Height).Contains(dropZonePos)

            ? dropZonePos

            : new Point(DropZone.Bounds.Width / 2, DropZone.Bounds.Height / 2);

        var screenPoint = DropZone.PointToScreen(targetPos);

        AppHost.Get<RadialController>().ShowForFiles(screenPoint.X, screenPoint.Y, paths);

    }



    private void OnDrop(object? sender, DragEventArgs e)

    {

        DropZone.Classes.Remove("over");

        var dragged = DraggedFiles.Read(e.DataTransfer, forDrop: true);

        if (dragged.Files.Count == 0)

        {

            e.DragEffects = DragDropEffects.None;

            return;

        }



        e.DragEffects = DragDropEffects.Copy;

        var screenPoint = this.PointToScreen(e.GetPosition(this));

        AppHost.Get<RadialController>().ShowForFiles(screenPoint.X, screenPoint.Y, dragged.Files, web: dragged.Web);

    }

}

