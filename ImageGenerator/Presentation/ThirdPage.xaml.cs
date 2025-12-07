using Microsoft.UI.Xaml.Media.Animation;
using System.Diagnostics;

namespace ImageGenerator.Presentation;

public sealed partial class ThirdPage : Page
{
    private Stopwatch _stopwatch = new Stopwatch();
    private DispatcherTimer? _timer;
    private int _counter = 0;
    private int _dotsCounter = 0;
    private const int GenerationDurationSeconds = 5;

    public ThirdPage()
    {
        this.InitializeComponent();
        this.Loaded += ThirdPage_Loaded;
    }

    private void ThirdPage_Loaded(object sender, RoutedEventArgs e)
    {
        // Iniciar el cronómetro y timer inmediatamente
        _stopwatch.Start();
        StartTimer();
    }

    private void StartTimer()
    {
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }

    private async void Timer_Tick(object? sender, object e)
    {
        _counter++;
        var seconds = _stopwatch.Elapsed.Seconds;
        
        // Actualizar el texto del timer
        TimerText.Text = seconds.ToString();
        TimerTextNormal.Text = seconds.ToString();
        
        // Animar los puntos "Generating..."
        _dotsCounter = (_dotsCounter % 3) + 1;
        DotsText.Text = new string('.', _dotsCounter);

        if (_counter >= GenerationDurationSeconds)
        {
            _timer?.Stop();
            await StopGeneration();
        }
    }

    private async Task StopGeneration()
    {
        _stopwatch.Stop();

        // Cambiar texto a "Picture generated"
        TitleText.Text = "Picture\ngenerated";
        DotsText.Text = "";

        // Ocultar Lottie
        LottiePlayer.Stop();
        LottiePlayer.Opacity = 0;

        // Mostrar imagen y animación amarilla
        ImageBorder.Opacity = 1;
        ImageAnimation.Opacity = 0.9;

        // Animaciones paralelas
        var imageFadeStoryboard = CreateFadeAnimation(ImageAnimation, 0.9, 0, TimeSpan.FromMilliseconds(1000));
        var imageScaleStoryboard = CreateScaleAnimation(ImageAnimation, 1.0, 1.1, TimeSpan.FromMilliseconds(1000));
        var timerHighlightFadeIn = CreateFadeAnimation(TimerHighlight, 0, 1, TimeSpan.FromMilliseconds(1000));
        
        // Ejecutar animaciones en paralelo
        imageFadeStoryboard.Begin();
        imageScaleStoryboard.Begin();
        timerHighlightFadeIn.Begin();
        TimerTextNormal.Opacity = 0;

        await Task.Delay(1000);

        // Fade out del highlight del timer
        var timerHighlightFadeOut = CreateFadeAnimation(TimerHighlight, 1, 0, TimeSpan.FromMilliseconds(300));
        timerHighlightFadeOut.Begin();
        TimerTextNormal.Opacity = 1;

        await Task.Delay(300);

        // Mostrar botón Finish con animación de escala
        var buttonScaleStoryboard = CreateButtonScaleAnimation(FinishButtonScale, 0, 1, TimeSpan.FromMilliseconds(500));
        buttonScaleStoryboard.Begin();
    }

    private Storyboard CreateFadeAnimation(UIElement target, double from, double to, TimeSpan duration)
    {
        var animation = new DoubleAnimation
        {
            From = from,
            To = to,
            Duration = new Duration(duration),
            EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
        };

        Storyboard.SetTarget(animation, target);
        Storyboard.SetTargetProperty(animation, "Opacity");

        var storyboard = new Storyboard();
        storyboard.Children.Add(animation);
        return storyboard;
    }

    private Storyboard CreateScaleAnimation(UIElement target, double from, double to, TimeSpan duration)
    {
        // Para escala necesitamos usar RenderTransform
        if (target is FrameworkElement fe && fe.RenderTransform is not ScaleTransform)
        {
            fe.RenderTransform = new ScaleTransform { ScaleX = 1, ScaleY = 1 };
            fe.RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5);
        }

        var animationX = new DoubleAnimation
        {
            From = from,
            To = to,
            Duration = new Duration(duration),
            EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
        };

        var animationY = new DoubleAnimation
        {
            From = from,
            To = to,
            Duration = new Duration(duration),
            EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
        };

        Storyboard.SetTarget(animationX, target);
        Storyboard.SetTargetProperty(animationX, "(UIElement.RenderTransform).(ScaleTransform.ScaleX)");
        
        Storyboard.SetTarget(animationY, target);
        Storyboard.SetTargetProperty(animationY, "(UIElement.RenderTransform).(ScaleTransform.ScaleY)");

        var storyboard = new Storyboard();
        storyboard.Children.Add(animationX);
        storyboard.Children.Add(animationY);
        return storyboard;
    }

    private Storyboard CreateButtonScaleAnimation(ScaleTransform scaleTransform, double from, double to, TimeSpan duration)
    {
        var animationX = new DoubleAnimation
        {
            From = from,
            To = to,
            Duration = new Duration(duration),
            EasingFunction = new ElasticEase { EasingMode = EasingMode.EaseOut, Oscillations = 1, Springiness = 3 }
        };

        var animationY = new DoubleAnimation
        {
            From = from,
            To = to,
            Duration = new Duration(duration),
            EasingFunction = new ElasticEase { EasingMode = EasingMode.EaseOut, Oscillations = 1, Springiness = 3 }
        };

        Storyboard.SetTarget(animationX, scaleTransform);
        Storyboard.SetTargetProperty(animationX, "ScaleX");
        
        Storyboard.SetTarget(animationY, scaleTransform);
        Storyboard.SetTargetProperty(animationY, "ScaleY");

        var storyboard = new Storyboard();
        storyboard.Children.Add(animationX);
        storyboard.Children.Add(animationY);
        return storyboard;
    }
}
