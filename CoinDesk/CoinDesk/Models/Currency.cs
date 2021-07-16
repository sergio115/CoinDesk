using Newtonsoft.Json;
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
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [Ignore]
        public string RateString { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("rate")]
        public float Rate { get; set; }
    }
}
