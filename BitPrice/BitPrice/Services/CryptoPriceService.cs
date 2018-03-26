using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BitPrice.Models;

namespace BitPrice.Services
{
    class CryptoPriceService
    {
        HttpClient cliente;
        List<CryptoPrices> prices;
        public CryptoPriceService()
        {
            cliente = new HttpClient
            {
                MaxResponseContentBufferSize = 256000,
                Timeout = TimeSpan.FromSeconds(60000)
            };            
        }

        public async Task<List<CryptoPrices>> GetPrices()
        {
            prices = new List<CryptoPrices>();
            try
            {
                var uri = new Uri("https://api.coinmarketcap.com/v1/ticker/");
                var json = await cliente.GetStringAsync(uri);
                //var resp = JObject.Parse(json);
                var resp = JArray.Parse(json);

                if (!resp.Equals(0))
                {
                    prices = JsonConvert.DeserializeObject<List<CryptoPrices>>(json);
                }
                else
                {
                    prices = null;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR Catch: " + e.Message);
            }
            return prices;
        }
    }
}
