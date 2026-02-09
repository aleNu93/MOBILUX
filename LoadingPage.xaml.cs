using System.Threading;

namespace MOBILUX.Pages;

public partial class LoadingPage : ContentPage
{
    private CancellationTokenSource? _cts;

    public LoadingPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        _cts = new CancellationTokenSource();

        _ = PulseTextAsync(_cts.Token);
        _ = PulseLogoAsync(_cts.Token);

        await Task.Delay(3000);

        _cts.Cancel();

        await Shell.Current.GoToAsync("login");
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _cts?.Cancel();
    }

    private async Task PulseTextAsync(CancellationToken token)
    {
        try
        {
            while (!token.IsCancellationRequested)
            {
                await LoadingLabel.FadeToAsync(0.35, 500, Easing.CubicInOut);
                await LoadingLabel.FadeToAsync(0.9, 500, Easing.CubicInOut);
            }
        }
        catch { }
    }

    private async Task PulseLogoAsync(CancellationToken token)
    {
        try
        {
            while (!token.IsCancellationRequested)
            {
                await LoadingImage.ScaleToAsync(0.98, 600, Easing.CubicInOut);
                await LoadingImage.ScaleToAsync(1.0, 600, Easing.CubicInOut);
            }
        }
        catch { }
    }
}
