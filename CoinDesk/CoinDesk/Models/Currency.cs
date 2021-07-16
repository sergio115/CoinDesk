using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinDesk.Models
{
    public class Currency
    {
        [PrimaryKey, AutoIncrement]
        public int IdCurrency { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
        [Ignore]
        public string RateString { get; set; }
        public string Description { get; set; }
        public float Rate { get; set; }
    }
}
