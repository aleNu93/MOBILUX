using MOBILUX.Pages;

namespace MOBILUX;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("register", typeof(RegisterPage));
        Routing.RegisterRoute("recover", typeof(PasswordUserRecoveryPage));
        Routing.RegisterRoute("PurchaseListPage", typeof(PurchaseListPage));
        Routing.RegisterRoute("PurchaseDetailPage", typeof(PurchaseDetailPage));
        Routing.RegisterRoute("PurchaseRegisterPage", typeof(PurchaseRegisterPage));
        Routing.RegisterRoute("PaymentCreatePage", typeof(PaymentCreatePage));
        Routing.RegisterRoute("ProfilePage", typeof(ProfilePage));
        Routing.RegisterRoute("ReportsPage", typeof(ReportsPage));
        Routing.RegisterRoute("HelpPage", typeof(HelpPage));
    }
}
