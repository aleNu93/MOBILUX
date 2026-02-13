using System.Net.Mail;
using System.Text.Json;
using Microsoft.Maui.Storage;
using MOBILUX.Models;

namespace MOBILUX.Pages;

public partial class ProfilePage : ContentPage
{
    // ====== ORIGINAL ======
    public Client Client { get; set; } = new();

    public bool UsarCorreoSecundario { get; set; } = false;

    public string ErrorCorreoPrincipal { get; set; } = "";
    public bool MostrarErrorCorreoPrincipal { get; set; } = false;

    public string ErrorCorreoSecundario { get; set; } = "";
    public bool MostrarErrorCorreoSecundario { get; set; } = false;

    private const string ClientKey = "CLIENT_PROFILE";

    // ====== MENU ======
    private bool _menuExpanded;
    public double MenuMaxHeight { get; private set; } = 220;

    public ProfilePage()
    {
        InitializeComponent();

        LoadClient();

        UsarCorreoSecundario = !string.IsNullOrWhiteSpace(Client.EmailSecondary);

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

    // ====== MENU HANDLERS ======
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

    // ====== ORIGINAL LOGIC ======
    private void LoadClient()
    {
        var json = Preferences.Get(ClientKey, "");

        if (string.IsNullOrWhiteSpace(json))
        {
            Client = new Client
            {
                FullName = "",
                IdNumber = "",
                Phone = "",
                EmailPrimary = "",
                EmailSecondary = "",
                EmailNotificationsEnabled = true
            };
            return;
        }

        try
        {
            Client = JsonSerializer.Deserialize<Client>(json) ?? new Client();
        }
        catch
        {
            Client = new Client();
        }
    }

    private void SaveClient()
    {
        var json = JsonSerializer.Serialize(Client);
        Preferences.Set(ClientKey, json);
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        LimpiarErrores();

        if (string.IsNullOrWhiteSpace(Client.EmailPrimary) || !IsValidEmail(Client.EmailPrimary))
        {
            ErrorCorreoPrincipal = "Ingrese un correo principal válido.";
            MostrarErrorCorreoPrincipal = true;
            RefrescarBinding();
            return;
        }

        if (UsarCorreoSecundario)
        {
            if (string.IsNullOrWhiteSpace(Client.EmailSecondary) || !IsValidEmail(Client.EmailSecondary))
            {
                ErrorCorreoSecundario = "El correo secundario no es válido.";
                MostrarErrorCorreoSecundario = true;
                RefrescarBinding();
                return;
            }
        }
        else
        {
            Client.EmailSecondary = "";
        }

        SaveClient();
        await DisplayAlert("Listo", "Perfil actualizado correctamente.", "OK");
    }

    private async void OnCerrarSesionClicked(object sender, EventArgs e)
    {
        // ✅ FIX: tu ShellContent root es login
        await Shell.Current.GoToAsync("//login");
    }

    private void OnToggleCorreoSecundario(object sender, ToggledEventArgs e)
    {
        UsarCorreoSecundario = e.Value;

        SecondaryEmailEntry.IsEnabled = UsarCorreoSecundario;
        SecondaryEmailEntry.Opacity = UsarCorreoSecundario ? 1 : 0.5;

        if (!UsarCorreoSecundario)
        {
            Client.EmailSecondary = "";
            ErrorCorreoSecundario = "";
            MostrarErrorCorreoSecundario = false;
        }

        BindingContext = null;
        BindingContext = this;
    }

    private void LimpiarErrores()
    {
        ErrorCorreoPrincipal = "";
        MostrarErrorCorreoPrincipal = false;

        ErrorCorreoSecundario = "";
        MostrarErrorCorreoSecundario = false;
    }

    private void RefrescarBinding()
    {
        BindingContext = null;
        BindingContext = this;
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
