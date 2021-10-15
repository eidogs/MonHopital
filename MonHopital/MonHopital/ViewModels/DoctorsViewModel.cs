using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Net.Http;
using MonHopital.Models;
using System;
using Xamarin.Forms;

namespace MonHopital.ViewModels
{
    class DoctorsViewModel : BaseViewModel
    {
        public DoctorsViewModel()
        {
            Title = "Personnel";
            GetDoctors();
        }
        public ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();
        public ObservableCollection<Doctor> Doctors { get { return doctors; } }
        public async void GetDoctors()
        {
            try
            {
                IsBusy = true;
                HttpClient HttpClient = new HttpClient();
                string Response = await HttpClient.GetStringAsync("https://hospitalwebapi.herokuapp.com/api/doctors/");
                ObservableCollection<Doctor> FetchedDoctors = JsonConvert.DeserializeObject<ObservableCollection<Doctor>>(Response);
                for (int i = 0; i < FetchedDoctors.Count; i++)
                {
                    doctors.Add(FetchedDoctors[i]);
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
