namespace MOBILUX.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // Frontend only (sin backend)
        await Shell.Current.GoToAsync("dashboard");
    }
}
