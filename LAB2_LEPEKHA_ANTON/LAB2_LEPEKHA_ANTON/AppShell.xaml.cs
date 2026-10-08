using LAB2_LEPEKHA_ANTON.Views;

namespace LAB2_LEPEKHA_ANTON;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("studentdetail", typeof(StudentDetailPage));
    }
}