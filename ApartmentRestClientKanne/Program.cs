using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


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


                Task<HttpResponseMessage> task = client.GetAsync("apartment/");

                Console.WriteLine(task);
            }
   
            Console.ReadLine();
        }
    }
}
