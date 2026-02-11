namespace MOBILUX.Pages;

public partial class DashboardPage : ContentPage
{
    private bool _menuExpanded;

    public double DashboardImageHeight { get; private set; } = 520;

    public DashboardPage()
    {
        InitializeComponent();

        BindingContext = this;

        _menuExpanded = false;
        MenuItems.IsVisible = false;
        MenuArrow.Rotation = 0;
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        if (height <= 0) return;

        // Ajuste para que NO queden gigantes en móviles.
        // Reservamos espacio para logo arriba y menú abajo.
        var newHeight = Math.Max(320, height - 260);

        if (Math.Abs(DashboardImageHeight - newHeight) > 1)
        {
            DashboardImageHeight = newHeight;
            OnPropertyChanged(nameof(DashboardImageHeight));
        }
    }

    private void OnToggleMenuTapped(object sender, EventArgs e)
    {
        _menuExpanded = !_menuExpanded;
        MenuItems.IsVisible = _menuExpanded;
        MenuArrow.Rotation = _menuExpanded ? 180 : 0;
    }

    private async void OnPurchasesListClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("PurchaseListPage");

    private async void OnPurchaseDetailClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("PurchaseDetailPage");

    private async void OnPurchaseRegisterClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("PurchaseRegisterPage");

    private async void OnPaymentCreateClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("PaymentCreatePage");

    private async void OnProfileClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("ProfilePage");

    private async void OnHelpClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("HelpPage");
}
