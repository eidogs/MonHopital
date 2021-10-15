using System.Collections.ObjectModel;
using MonHopital.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using Xamarin.Forms;

namespace MonHopital.ViewModels
{
    class ServicesViewModel : BaseViewModel
    {        
        ObservableCollection<Service> services = new ObservableCollection<Service>();
        public ServicesViewModel()
        {
            Title = "Services";
            GetServices();
        }
        public ObservableCollection<Service> Services { get { return services; } }
        public async void GetServices()    
        {
            try
            {
                IsBusy = true;
                HttpClient HttpClient = new HttpClient();
                string Response = await HttpClient.GetStringAsync("https://hospitalwebapi.herokuapp.com/api/services/");
                ObservableCollection<Service> FetchedServices = JsonConvert.DeserializeObject<ObservableCollection<Service>>(Response);
                for (int i = 0; i < FetchedServices.Count; i++)
                {
                    services.Add(FetchedServices[i]);
                }
                IsBusy = false;
            } catch(Exception e)
            {
                IsBusy = false;
                MessagingCenter.Send(this, "Error", e.Message);
            }

        }

    }
}
