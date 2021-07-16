using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoinDesk
{
    public static class Constants
    {
        private const string DatabaseFileName = "SQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFileName);
            }
        }

        public static string BaseAddress = "https://api.coindesk.com";
        public static string APIUrl = BaseAddress + "/v1/bpi/currentprice.json";
    }
}
