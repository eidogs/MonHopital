using Xamarin.Forms;
using MonHopital.Views;

namespace MonHopital.ViewModels
{
    class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            Title = "Accueil";
            TitleBackgroundColor = Color.FromRgba(0, 0, 0, 0.6);
            NavigationCommand = new Command<string>(page => NavigateToPage(page));
        }

        public Color TitleBackgroundColor { get; }
        public Command NavigationCommand { get; set; }

        private async void NavigateToPage(string page)
        {
            await Shell.Current.GoToAsync(page);
        }
    }
}
