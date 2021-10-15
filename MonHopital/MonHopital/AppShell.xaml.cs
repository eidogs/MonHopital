using MonHopital.Views;
using Xamarin.Forms;

namespace MonHopital
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ServicesPage), typeof(ServicesPage));
            Routing.RegisterRoute(nameof(SpecialitiesPage), typeof(SpecialitiesPage));
            Routing.RegisterRoute(nameof(DoctorsPage), typeof(DoctorsPage));
        }
    }
}
