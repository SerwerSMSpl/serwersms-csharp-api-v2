using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics.Tracing;
using System.Net.Http;
using System.Threading.Tasks;
using SerwerSMS.Lib;

namespace SerwerSMS
{

    public class SerwerSms
    {
        public Messages Messages { get; }
        public Files Files { get; }
        public Blacklist Blacklist { get; }
        public Errors Error { get; }
        public Phones Phones { get; }
        public Stats Stats { get; }
        public Account Account { get; }
        public Contacts Contacts { get; }
        public Groups Groups { get; }
        public Payments Payments { get; }
        public Senders Senders { get; }
        public Premium Premium { get; }
        public Templates Templates { get; }
        public Subaccounts Subaccounts { get; }

        private readonly string _apiUrl;
        private readonly string _system = "client_csharp";
        private readonly string _username;
        private readonly string _password;
        private readonly string _format;
        private readonly ILogger _logger;

        public SerwerSms(string username, 
            string password, 
            ResponseFormat format = ResponseFormat.Json, 
            string apiUrl = "http://s1api2.serwersms.pl/", 
            ILogger logger = null)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) {

                throw new ArgumentException("Brak danych: username, password");
            }

            _logger = logger;
            _username = username;
            _password = password;
            _format = format == ResponseFormat.Json ? "json" : "xml";
            _apiUrl = apiUrl;

            Messages = new Messages(this);
            Files = new Files(this);
            Blacklist = new Blacklist(this);
            Error = new Errors(this);
            Phones = new Phones(this);
            Stats = new Stats(this);
            Account = new Account(this);
            Contacts = new Contacts(this);
            Groups = new Groups(this);
            Payments = new Payments(this);
            Senders = new Senders(this);
            Premium = new Premium(this);
            Templates = new Templates(this);
            Subaccounts = new Subaccounts(this);            
        }

        public string Call(string url, Dictionary<string, string> data)
        {
            var response = PostDataAsync(url, data).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        public async Task<string> CallAsync(string url, Dictionary<string, string> data)
        {
            var response = await PostDataAsync(url, data);
            return await response.Content.ReadAsStringAsync();
        }

        public Stream CallStream(string url, Dictionary<string, string> data)
        {
            var response = PostDataAsync(url, data).Result;
            return response.Content.ReadAsStreamAsync().Result;
        }

        public async Task<Stream> CallStreamAsync(string url, Dictionary<string, string> data)
        {
            var response = PostDataAsync(url, data).Result;
            return await response.Content.ReadAsStreamAsync();
        }

        private async Task<HttpResponseMessage> PostDataAsync(string url, Dictionary<string, string> data)
        {
            data["username"] = _username;
            data["password"] = _password;
            data["system"] = _system;

            string json = JsonConvert.SerializeObject(data);

            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var uri = $"{_apiUrl}{url}.{_format}";

            _logger?.Log($"Request content:{json}", EventLevel.Verbose);

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(uri, stringContent).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    _logger?.Log($"Response received - StatusCode:{response.StatusCode}", EventLevel.Error);
                    throw new Exception($"Request failed. Response StatusCode:{response.StatusCode}");
                }

                _logger?.Log($"Response received - StatusCode:{response.StatusCode}", EventLevel.Informational);

                return response;
            }
        }
    }
}