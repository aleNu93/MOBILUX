using Microsoft.Maui.ApplicationModel;

namespace MOBILUX.Pages;

public partial class HelpPage : ContentPage
{
    private bool _menuExpanded;

    public double MenuMaxHeight { get; private set; } = 220;

    public HelpPage()
    {
        InitializeComponent();
        BindingContext = this;

        _menuExpanded = false;
        MenuScroll.IsVisible = false;
        MenuArrow.Rotation = 0;
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        if (height <= 0) return;

        var newMenuHeight = Math.Max(180, height * 0.35);
        if (Math.Abs(MenuMaxHeight - newMenuHeight) > 1)
        {
            MenuMaxHeight = newMenuHeight;
            OnPropertyChanged(nameof(MenuMaxHeight));
        }
    }

    private void OnToggleMenuTapped(object sender, EventArgs e)
    {
        _menuExpanded = !_menuExpanded;
        MenuScroll.IsVisible = _menuExpanded;
        MenuArrow.Rotation = _menuExpanded ? 180 : 0;
    }

    private async void OnDashboardClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("//dashboard");
    private async void OnPurchasesListClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("PurchaseListPage");
    private async void OnPurchaseDetailClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("PurchaseDetailPage");
    private async void OnPurchaseRegisterClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("PurchaseRegisterPage");
    private async void OnPaymentCreateClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("PaymentCreatePage");
    private async void OnProfileClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("ProfilePage");
    private async void OnHelpClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("HelpPage");
    private async void OnReportsClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("ReportsPage");
    private async void OnLogoutClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("//login");

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnContactSupportClicked(object sender, EventArgs e)
    {
        var email = "soporte@mobilux.com";
        var subject = "Soporte MOBILUX";
        var body = "Hola, necesito ayuda con:";

        try
        {
            var message = new EmailMessage
            {
                Subject = subject,
                Body = body,
                To = new List<string> { email }
            };

            await Email.Default.ComposeAsync(message);
        }
        catch
        {
            await DisplayAlert("Aviso", "No se pudo abrir el correo en este dispositivo.", "OK");
        }
    }
}
