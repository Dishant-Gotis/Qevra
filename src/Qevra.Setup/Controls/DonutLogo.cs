using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Qevra.Setup.Controls;

public sealed class DonutLogo : Control
{
    public static readonly StyledProperty<bool> AnimateProperty =
        AvaloniaProperty.Register<DonutLogo, bool>(nameof(Animate), true);

    private static readonly TimeSpan Duration = TimeSpan.FromMilliseconds(1000);
    private static readonly Bitmap? LogoBitmap;

    private readonly FrameLoop _loop;
    private double _progress;

    static DonutLogo()
    {
        AffectsRender<DonutLogo>(AnimateProperty);
        try
        {
            using var stream = AssetLoader.Open(new Uri("avares://Qevra.Setup/Assets/Icons/qevra.png"));
            LogoBitmap = new Bitmap(stream);
        }
        catch
        {
            // Fallback if asset is unavailable
        }
    }

    public DonutLogo()
    {
        FlowDirection = FlowDirection.LeftToRight;
        _progress = SetupMotion.Enabled ? 0 : 1;
        _loop = new FrameLoop(this, elapsed =>
        {
            _progress = Math.Min(1, elapsed / Duration);
            InvalidateVisual();
            return _progress < 1;
        });
    }

    public bool Animate { get => GetValue(AnimateProperty); set => SetValue(AnimateProperty, value); }

    public void Replay()
    {
        if (!SetupMotion.Enabled || !Animate)
            return;
        _progress = 0;
        _loop.Restart();
    }

    protected override Size MeasureOverride(Size availableSize)
    {
        var side = Math.Min(double.IsInfinity(availableSize.Width) ? 96 : availableSize.Width,
            double.IsInfinity(availableSize.Height) ? 96 : availableSize.Height);
        return new Size(side, side);
    }

    public override void Render(DrawingContext context)
    {
        var progress = Animate && SetupMotion.Enabled ? _progress : 1;
        var side = Math.Min(Bounds.Width, Bounds.Height);
        if (side <= 0 || LogoBitmap == null)
            return;

        var scale = 0.5 + 0.5 * BackOut(Math.Clamp(progress, 0, 1));
        var opacity = Math.Clamp(progress * 1.5, 0, 1);
        var origin = new Point((Bounds.Width - side) / 2, (Bounds.Height - side) / 2);
        var center = new Point(Bounds.Width / 2, Bounds.Height / 2);

        var transform = Matrix.CreateTranslation(-center.X, -center.Y)
                        * Matrix.CreateScale(scale, scale)
                        * Matrix.CreateTranslation(center.X, center.Y);

        using (context.PushTransform(transform))
        using (context.PushOpacity(opacity))
        {
            var destRect = new Rect(origin.X, origin.Y, side, side);
            context.DrawImage(LogoBitmap, destRect);
        }
    }

    internal static double EaseOut(double t) => 1 - Math.Pow(1 - t, 3);

    internal static double BackOut(double t)
    {
        const double c1 = 1.70158;
        const double c3 = c1 + 1;
        return 1 + c3 * Math.Pow(t - 1, 3) + c1 * Math.Pow(t - 1, 2);
    }
}
