using CoinDesk.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoinDesk.Services
{
    public class DataManager
    {
        ICoinDeskService sRest;
        public DataManager(ICoinDeskService service)
        {
            sRest = service;
        }

        public Task<List<Currency>> GetFromAPI()
        {
            return sRest.GetCurrenciesAsync();
        }
    }
}
