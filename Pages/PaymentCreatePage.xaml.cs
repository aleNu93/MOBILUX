namespace MOBILUX.Pages;

public partial class PaymentCreatePage : ContentPage
{
    private bool _menuExpanded;

    public double MenuMaxHeight { get; private set; } = 220;

    public PaymentCreatePage()
    {
        InitializeComponent();

        BindingContext = this;

        PickerCompra.SelectedIndex = 0;
        DateAbono.Date = DateTime.Today;

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

    private async void OnGuardarAbonoClicked(object sender, EventArgs e)
    {
        if (PickerCompra.SelectedIndex < 0 || string.IsNullOrWhiteSpace(EntryAbono.Text))
        {
            await DisplayAlert("Faltan datos",
                "Seleccioná la compra y meté el monto del abono.",
                "OK");
            return;
        }

        await DisplayAlert("Listo", "Abono registrado", "OK");
        await Shell.Current.GoToAsync("..");
    }

    private async void OnVolverClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("..");
}
