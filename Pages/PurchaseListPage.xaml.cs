using MOBILUX.Models;
using System.Collections.Generic;
using System.Linq;

namespace MOBILUX.Pages;

public partial class PurchaseListPage : ContentPage
{
    private bool _menuExpanded;

    public double MenuMaxHeight { get; private set; } = 220;

    public decimal TotalInvested { get; set; }
    public decimal TotalPending { get; set; }

    public PurchaseListPage()
    {
        InitializeComponent();
        BindingContext = this;

        LoadMockData();
        PurchaseCollection.SelectionChanged += OnSelectionChanged;

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

    private void LoadMockData()
    {
        var purchases = new List<Purchase>
        {
            new Purchase
            {
                Id = "1",
                ProductName = "Sofá Cuero Italiano",
                TotalPrice = 850000,
                RemainingBalance = 450000,
                PurchaseDate = DateTime.Now.AddMonths(-2),
                Status = "Activa"
            },
            new Purchase
            {
                Id = "2",
                ProductName = "Mesa Comedor Roble",
                TotalPrice = 420000,
                RemainingBalance = 0,
                PurchaseDate = DateTime.Now.AddMonths(-6),
                Status = "Cancelada"
            }
        };

        PurchaseCollection.ItemsSource = purchases;

        TotalInvested = purchases.Sum(p => p.TotalPrice);
        TotalPending = purchases.Sum(p => p.RemainingBalance);

        OnPropertyChanged(nameof(TotalInvested));
        OnPropertyChanged(nameof(TotalPending));
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selected = e.CurrentSelection.FirstOrDefault() as Purchase;
        if (selected == null) return;

        var parameters = new Dictionary<string, object>
        {
            { "purchase", selected }
        };

        await Shell.Current.GoToAsync("PurchaseDetailPage", parameters);
        PurchaseCollection.SelectedItem = null;
    }

    // Acciones originales
    private async void OnPurchaseRegisterClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("PurchaseRegisterPage");

    private async void OnPaymentCreateClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("PaymentCreatePage");

    // Menú
    private void OnToggleMenuTapped(object sender, EventArgs e)
    {
        _menuExpanded = !_menuExpanded;
        MenuScroll.IsVisible = _menuExpanded;
        MenuArrow.Rotation = _menuExpanded ? 180 : 0;
    }

    private async void OnDashboardClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("//dashboard");
    private async void OnPurchasesListClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("PurchaseListPage");
    private async void OnPurchaseDetailClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("PurchaseDetailPage");
    private async void OnPurchaseRegisterClickedMenu(object sender, EventArgs e) => await Shell.Current.GoToAsync("PurchaseRegisterPage");
    private async void OnPaymentCreateClickedMenu(object sender, EventArgs e) => await Shell.Current.GoToAsync("PaymentCreatePage");
    private async void OnProfileClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("ProfilePage");
    private async void OnHelpClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("HelpPage");
    private async void OnReportsClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("ReportsPage");
    private async void OnLogoutClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("//login");
}
