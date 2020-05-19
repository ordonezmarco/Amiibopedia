using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Amiibopedia.Helpers
{
    public class HttpHelper <T>
    {
        public async Task<T> GetRestServiceDataAsync(string serviceAddress)
        {
            //lo que hacemos de cualquier  resultado tipo rest lo
            //deserealizamos correcto de acuerdo al metodo indicado
            var client = new HttpClient();
            client.BaseAddress = new Uri(serviceAddress);

            var response =
                await client.GetAsync(client.BaseAddress);

            response.EnsureSuccessStatusCode();
            //como esasyncrono
            var jsonResult =
               await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(jsonResult);
            return result;
        }
    }
}
