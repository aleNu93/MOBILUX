using MOBILUX.Pages;

namespace MOBILUX;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("login", typeof(MOBILUX.Pages.LoginPage));
        Routing.RegisterRoute("register", typeof(RegisterPage));
        Routing.RegisterRoute("recover", typeof(PasswordUserRecoveryPage));
        Routing.RegisterRoute("dashboard", typeof(DashboardPage));
        Routing.RegisterRoute("PurchaseListPage", typeof(PurchaseListPage));
        Routing.RegisterRoute("PurchaseDetailPage", typeof(PurchaseDetailPage));
        Routing.RegisterRoute("PurchaseRegisterPage", typeof(PurchaseRegisterPage));
        Routing.RegisterRoute("PaymentCreatePage", typeof(PaymentCreatePage));
        Routing.RegisterRoute("ProfilePage", typeof(ProfilePage));
        Routing.RegisterRoute("HelpPage", typeof(HelpPage));
    }
}
