using MonHopital.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonHopital.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<ContactViewModel>(this, "MessageSent", async (sender) =>
            {
                await DisplayAlert("Statut", "Message envoyé avec succès", "OK");
            });
            MessagingCenter.Subscribe<ContactViewModel, string>(this, "PostError", async (sender, message) =>
            {
                await DisplayAlert("Erreur", message, "OK");
            });
        }
    }
}