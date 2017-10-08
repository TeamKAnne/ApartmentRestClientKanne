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

                string requeststr = "apartment/";
                
                var responseAsync = client.GetAsync(serverurl + requeststr).Result;

                if (responseAsync.IsSuccessStatusCode)
                {
                    aplist = (List<Apartment>)responseAsync.Content.ReadAsAsync<IList<Apartment>>().Result;

                    //aplist = responseAsync.Content.ReadAsAsync<IList<Apartment>>().Result as List<Apartment>;

                    
                    foreach (Apartment a in aplist)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Lejlighed til salg:");
                        
                        Console.WriteLine(a.ToString());
                    }
                }
            }

            using (var client = new HttpClient())
            {
                const string serverurl =
                    "http://apartmentrestkanne20171003122404.azurewebsites.net/ApartmentService.svc/";

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.BaseAddress = new Uri(serverurl);

                string requeststr = "apartment/postalcode/{code}";

                var responseAsyncPC = client.GetAsync(serverurl + requeststr).Result;

                if (responseAsyncPC.IsSuccessStatusCode)
                {
                    aplist = (List<Apartment>) responseAsyncPC.Content.ReadAsAsync<IList<Apartment>>().Result;
                }

                Console.WriteLine();
                Console.WriteLine("Sortering på postnummer:");

                foreach (Apartment a in aplist)
                {
                    Console.WriteLine();
                    Console.WriteLine(a.ToString());
                }
            }


            using (var client = new HttpClient())
            {
                const string serverurl =
                    "http://apartmentrestkanne20171003122404.azurewebsites.net/ApartmentService.svc/";

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.BaseAddress = new Uri(serverurl);

                string requeststr = "apartment/location/{location}";

                var responseAsyncLocation = client.GetAsync(serverurl + requeststr).Result;

                if (responseAsyncLocation.IsSuccessStatusCode)
                {
                    aplist = (List<Apartment>) responseAsyncLocation.Content.ReadAsAsync<IList<Apartment>>().Result;

                    Console.WriteLine();
                    Console.WriteLine("Sortering på sted (Å er pt et problem):");

                    foreach (Apartment a in aplist)
                    {
                        Console.WriteLine();
                        Console.WriteLine(a.ToString());
                    }
                }
            }
   
            Console.ReadLine();
        }
    }
}
