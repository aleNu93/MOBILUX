using MOBILUX.Models;

namespace MOBILUX.Pages;

[QueryProperty(nameof(Purchase), "purchase")]
public partial class PurchaseDetailPage : ContentPage
{
    private bool _menuExpanded;
    public double MenuMaxHeight { get; private set; } = 220;

    private Purchase _purchase;

    public PurchaseDetailPage()
    {
        InitializeComponent();

        _menuExpanded = false;
        MenuScroll.IsVisible = false;
        MenuArrow.Rotation = 0;

        if (_purchase == null)
        {
            Purchase = new Purchase
            {
                Id = "001",
                ProductName = "Sofá Cuero Italiano",
                TotalPrice = 850000,
                RemainingBalance = 450000,
                PurchaseDate = DateTime.Now.AddMonths(-2),
                Status = "Activa"
            };
        }
    }

    public Purchase Purchase
    {
        get => _purchase;
        set
        {
            _purchase = value;
            BindingContext = _purchase; // se mantiene para tus bindings de datos
        }
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        if (height <= 0) return;

        var ideal = height * 0.35;
        var capped = Math.Min(ideal, 320);
        var newMenuHeight = Math.Max(180, capped);

        if (Math.Abs(MenuMaxHeight - newMenuHeight) > 1)
        {
            MenuMaxHeight = newMenuHeight;
            OnPropertyChanged(nameof(MenuMaxHeight)); // ✅ esto actualiza el x:Reference binding
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
    private async void OnPaymentCreateClickedMenu(object sender, EventArgs e) => await Shell.Current.GoToAsync("PaymentCreatePage");
    private async void OnProfileClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("ProfilePage");
    private async void OnHelpClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("HelpPage");
    private async void OnReportsClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("ReportsPage");
    private async void OnLogoutClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("//login");

    private async void OnPaymentCreateClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("PaymentCreatePage");
}
