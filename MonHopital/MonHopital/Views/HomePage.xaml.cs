using MonHopital.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonHopital.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<ServicesViewModel, string>(this, "Error", async (sender, message) =>
            {
                await DisplayAlert("Network Error", message, "OK");
            });
            MessagingCenter.Subscribe<SpecialitiesViewModel, string>(this, "Error", async (sender, message) =>
            {
                await DisplayAlert("Network Error", message, "OK");
            });
            MessagingCenter.Subscribe<DoctorsViewModel, string>(this, "Error", async (sender, message) =>
            {
                await DisplayAlert("Network Error", message, "OK");
            });
        }
    }
}