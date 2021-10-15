using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MonHopital.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "A Propos";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://angularhospitalsite.netlify.app"));
        }

        public ICommand OpenWebCommand { get; }
    }
}