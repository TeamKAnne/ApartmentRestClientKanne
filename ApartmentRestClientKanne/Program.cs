using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApartmentRestClientKanne
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Apartment> aplist = new List<Apartment>();

            using (var client = new HttpClient())
            {
                const string serverurl = "http://apartmentrestkanne20171003122404.azurewebsites.net/ApartmentService.svc/";

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                client.BaseAddress = new Uri(serverurl);

                string lol = "apartment/";
                //Task<HttpResponseMessage> task = client.GetAsync(serverurl + lol);
                var responseAsync = client.GetAsync(serverurl + lol).Result;

                if (responseAsync.IsSuccessStatusCode)
                {
                    aplist = (List<Apartment>)responseAsync.Content.ReadAsAsync<IList<Apartment>>().Result;
                    //aplist = responseAsync.Content.

                    foreach (Apartment a in aplist)
                    {
                        Console.WriteLine(a);
                    }
                }
                //Console.WriteLine(task.Result);
            }
   
            Console.ReadLine();
        }
    }
}
