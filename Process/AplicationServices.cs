using System.Configuration;
using System.Net.Http;

namespace Process
{
    public static class AplicationServices
    {

        public static async void ProcessConsumer()
        {
            var URI = ConfigurationManager.AppSettings["Uri"];
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var AplicationJsonString = await response.Content.ReadAsStringAsync();

                    }
                }
            }
        }
    }
}
