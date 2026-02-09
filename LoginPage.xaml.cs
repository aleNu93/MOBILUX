namespace MOBILUX.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Frontend only
        await DisplayAlert("Login", "Frontend only (no backend).", "OK");
    }

    private async void OnRecoverTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("recover");
    }

    private async void OnRegisterTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("register");
    }
}
