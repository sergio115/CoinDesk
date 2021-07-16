using CoinDesk.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoinDesk.Services
{
    public interface ICoinDeskService
    {
        Task<List<Currency>> GetCurrenciesAsync();
    }
}
