namespace MOBILUX.Pages;

public partial class PasswordUserRecoveryPage : ContentPage
{
    public PasswordUserRecoveryPage()
    {
        InitializeComponent();
    }
    private void OnRecoverEmailChanged(object sender, TextChangedEventArgs e)
    {
        var text = (e.NewTextValue ?? string.Empty).Trim();
        EmailSentBubble.IsVisible = text.Length >= 5 && text.Contains("@");
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // Frontend only (sin backend)
        await Shell.Current.GoToAsync("//dashboard");
    }
}