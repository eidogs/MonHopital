using Xamarin.Forms;
using Newtonsoft.Json;
using MonHopital.Models;
using System.Net.Http;
using System.Text;
using System;

namespace MonHopital.ViewModels
{
    class ContactViewModel : BaseViewModel
    {
        string name = "";
        string email = "";
        string number = "";
        string subject = "";
        string content = "";
        bool error = false;
        public ContactViewModel()
        {
            Title = "Contact";
            SendMessageCommand = new Command(SendMessage);
        }

        public string Name { get { return name; } set { SetProperty(ref name, value);  } }
        public string Email { get { return email; } set { SetProperty(ref email, value); } }
        public string Number { get { return number; } set { SetProperty(ref number, value); } }
        public string Subject { get { return subject; } set { SetProperty(ref subject, value); } }
        public string Content { get { return content; } set { SetProperty(ref content, value); } }
        public bool Error { get { return error; } set { SetProperty(ref error, value); } }
        public Command SendMessageCommand { get; set; }

        private async void SendMessage()
        {
            if (Name == "")
            {
                return;
            }
            if (Email == "")
            {
                return;
            }
            if (Content == "")
            {
                return;
            }               
            try
            {
                IsBusy = true;
                Message message = new Message()
                {
                    name = Name,
                    email = Email,
                    number = Number,
                    subject = Subject,
                    content = Content
                };
                string data = JsonConvert.SerializeObject(message);
                StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.PostAsync("https://hospitalwebapi.herokuapp.com/api/messages/", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Message successfully sent");
                    Error = false;
                    MessagingCenter.Send(this, "MessageSent");
                }
                else
                {
                    Console.WriteLine(response);
                    Error = true;
                }
                IsBusy = false;
            } catch(Exception e)
            {
                IsBusy = false;
                MessagingCenter.Send(this, "PostError", e.Message);
            }
        }
    }
}
