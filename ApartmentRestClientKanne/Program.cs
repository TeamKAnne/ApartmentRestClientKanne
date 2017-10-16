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

            using (var getClient = new HttpClient())
            {
                const string serverurl =
                    "http://apartmentrestkanne20171003122404.azurewebsites.net/ApartmentService.svc/";

                getClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                getClient.BaseAddress = new Uri(serverurl);

                string requeststr = "apartment/";

                var responseAsync = getClient.GetAsync(serverurl + requeststr).Result;

                if (responseAsync.IsSuccessStatusCode)
                {
                    aplist = (List<Apartment>) responseAsync.Content.ReadAsAsync<IList<Apartment>>().Result;

                    //aplist = responseAsync.Content.ReadAsAsync<IList<Apartment>>().Result as List<Apartment>;


                    foreach (Apartment a in aplist)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Lejlighed til salg:");

                        Console.WriteLine(a.ToString());
                    }
                }
            }

            using (var getPostNrClient = new HttpClient())
            {
                const string serverurl =
                    "http://apartmentrestkanne20171003122404.azurewebsites.net/ApartmentService.svc/";

                getPostNrClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                getPostNrClient.BaseAddress = new Uri(serverurl);

                string requeststr = "apartment/postalcode/{code}";

                var responseAsyncPC = getPostNrClient.GetAsync(serverurl + requeststr).Result;

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


            using (var getLokationClient = new HttpClient())
            {
                const string serverurl =
                    "http://apartmentrestkanne20171003122404.azurewebsites.net/ApartmentService.svc/";

                getLokationClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                getLokationClient.BaseAddress = new Uri(serverurl);

                string requeststr = "apartment/location/{location}";

                var responseAsyncLocation = getLokationClient.GetAsync(serverurl + requeststr).Result;

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


            using (var postClient = new HttpClient())
            {
                const string serverurl =
                    "http://apartmentrestkanne20171003122404.azurewebsites.net/ApartmentService.svc/";

                postClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                Apartment apartment = new Apartment
                {
                    Price = 1000,
                    Location = "Test",
                    PostalCode = 40,
                    NoRoom = 5,
                    Size = 666,
                    WashingMachine = true,
                    Dishwasher = true
                };

                postClient.BaseAddress = new Uri(serverurl);

                var response = postClient.PostAsJsonAsync("apartments/", apartment).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Succes");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }

            using (var putClient = new HttpClient())
            {
                const string serverurl =
                    "http://apartmentrestkanne20171003122404.azurewebsites.net/ApartmentService.svc/";

                putClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                Apartment newApartment = new Apartment
                {
                    Price = 1000,
                    Location = "PLACEBOput",
                    PostalCode = 40,
                    NoRoom = 5,
                    Size = 666,
                    WashingMachine = true,
                    Dishwasher = true
                };

                putClient.BaseAddress = new Uri(serverurl);

                var response = putClient.PutAsJsonAsync("apartments/1", newApartment).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                }
                else
                    Console.Write("Error");
            }


            using (var deleteClient = new HttpClient())
            {
                const string serverurl =
                    "http://apartmentrestkanne20171003122404.azurewebsites.net/ApartmentService.svc/";

                deleteClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                deleteClient.BaseAddress = new Uri(serverurl);

                var response = deleteClient.DeleteAsync("apartments/21").Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine();
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Error");
                }

            }

            Console.ReadLine();
        }
    }
}
