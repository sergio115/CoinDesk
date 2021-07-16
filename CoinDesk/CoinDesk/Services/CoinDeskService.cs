using CoinDesk.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinDesk.Services
{
    public class CoinDeskService : ICoinDeskService
    {
        HttpClient _cliente;

        public List<Currency> Currencies { get; set; }

        public CoinDeskService()
        {
            _cliente = new HttpClient();
        }

        public async Task<List<Currency>> GetCurrenciesAsync()
        {
            Currencies = new List<Currency>();
            var uri = new Uri(string.Format(Constants.APIUrl, string.Empty));

            try
            {
                var response = await _cliente.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var jCryptoCurrency = JObject.Parse(content);
                    var coin = jCryptoCurrency["bpi"];
                    foreach (var item in coin)
                    {
                        var currency = new Currency();
                        currency.Code = item.First()["code"].ToString();
                        currency.Symbol = item.First()["symbol"].ToString();
                        currency.Description = item.First()["description"].ToString();
                        currency.Rate = float.Parse(item.First()["rate"].ToString());

                        Currencies.Add(currency);
                    }

                    return Currencies;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return null;
        }

    }
}
