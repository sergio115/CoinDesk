using CoinDesk.Repositories;
using CoinDesk.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoinDesk
{
    public partial class App : Application
    {
        private static CurrencyRepository _currencyRepository;
        public static CurrencyRepository CurrencyRepository
        {
            get
            {
                if (_currencyRepository == null)
                {
                    _currencyRepository = new CurrencyRepository();
                }
                return _currencyRepository;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new CurrencyPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
