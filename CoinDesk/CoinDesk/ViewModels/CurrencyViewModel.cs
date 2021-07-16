using CoinDesk.Models;
using CoinDesk.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CoinDesk.ViewModels
{
    public class CurrencyViewModel : BaseViewModel
    {
        public static DataManager DatMan { get; private set; }
        private Currency _currency;
        public Currency NewCurrency
        {
            get { return _currency; }
            set { SetValue(ref _currency, value); }
        }

        private List<Currency> _currencies;
        public List<Currency> Currencies
        {
            get { return _currencies; }
            set { SetValue(ref _currencies, value); } 
        }

        private int _idCurrency;
        public int IdCurrency
        {
            get { return _idCurrency; }
            set { SetValue(ref _idCurrency, value); }
        }

        private string _code;
        public string Code
        {
            get { return _code; }
            set { SetValue(ref _code, value); }
        }

        private string _symbol;
        public string Symbol
        {
            get { return _symbol; }
            set { SetValue(ref _symbol, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetValue(ref _description, value); }
        }

        private float _rate;
        public float Rate
        {
            get { return _rate; }
            set { SetValue(ref _rate, value); }
        }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public CurrencyViewModel()
        {
            NewCurrency = new Currency();
            NewCurrency.IdCurrency = this.IdCurrency;
            NewCurrency.Code = this.Code;
            NewCurrency.Symbol = this.Symbol;
            NewCurrency.Description = this.Description;
            NewCurrency.Rate = this.Rate;

            Refresh();
            AddCommand = new Command(async () => await AddOrUpdate());
            DeleteCommand = new Command(async (currency) => await Delete(((Currency)currency).IdCurrency));
        }
        private async Task AddOrUpdate()
        {
            App.CurrencyRepository.AddOrUpdate(NewCurrency);
            await Refresh ();
            //await Task.CompletedTask;
        }        
        private async Task Delete(int IdCurrency)
        {
            App.CurrencyRepository.Delete(IdCurrency);
            await Refresh();
            //await Task.CompletedTask;
        }
        private async Task Refresh()
        {
            Currencies = App.CurrencyRepository.GetAll();

            if (Currencies.Count.Equals(0))
            {
                DatMan = new DataManager(new CoinDeskService());
                Currencies = await DatMan.GetFromAPI();
                foreach (var currency in Currencies)
                {
                    App.CurrencyRepository.AddOrUpdate(currency);
                }
            }

            NewCurrency = new Currency();
            NewCurrency.IdCurrency = 0;
            NewCurrency.Code = "";
            NewCurrency.Symbol = "";
            NewCurrency.Description = "";
            NewCurrency.Rate = 0;
        }
    }
}
