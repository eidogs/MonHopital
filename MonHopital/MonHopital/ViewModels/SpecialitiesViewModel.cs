using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using MonHopital.Models;
using Xamarin.Forms;

namespace MonHopital.ViewModels
{
    class SpecialitiesViewModel : BaseViewModel
    {
        public SpecialitiesViewModel()
        {
            Title = "Spécialités";
            GetSpecialities();
        }
        public ObservableCollection<Speciality> specialities = new ObservableCollection<Speciality>();
        public ObservableCollection<Speciality> Specialities { get { return specialities; } }
        public async void GetSpecialities()
        {
            try
            {
                IsBusy = true;
                HttpClient HttpClient = new HttpClient();
                string Response = await HttpClient.GetStringAsync("https://hospitalwebapi.herokuapp.com/api/specialities/");
                ObservableCollection<Speciality> FetchedSpecialitys = JsonConvert.DeserializeObject<ObservableCollection<Speciality>>(Response);
                for (int i = 0; i < FetchedSpecialitys.Count; i++)
                {
                    specialities.Add(FetchedSpecialitys[i]);
                }
                IsBusy = false;
            } catch (Exception e)
            {
                IsBusy = false;
                MessagingCenter.Send(this, "Error", e.Message);
            }
        }
    }
}
