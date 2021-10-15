using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonHopital.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonHopital.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServicesPage : ContentPage
    {   
        ServicesViewModel _viewModel;
        public ServicesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ServicesViewModel();
        }
    }
}