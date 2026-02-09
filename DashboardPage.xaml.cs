namespace MOBILUX.Pages;

public partial class DashboardPage : ContentPage
{
    private bool _menuExpanded;

    public DashboardPage()
    {
        InitializeComponent();
        _menuExpanded = false;
        MenuItems.IsVisible = false;
        MenuArrow.Rotation = 0;
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
