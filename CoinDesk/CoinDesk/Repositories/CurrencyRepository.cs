using CoinDesk.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinDesk.Repositories
{
    public class CurrencyRepository
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public CurrencyRepository()
        {
            connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            connection.CreateTable<Currency>();
        }
        public void AddOrUpdate(Currency currency)
        {
            try
            {
                if (currency.IdCurrency != 0)
                {
                    connection.Update(currency);
                }
                else
                {
                    connection.Insert(currency);
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
        public List<Currency> GetAll()
        {
            try
            {
                return connection.Table<Currency>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }
        public Currency Get(int id)
        {
            try
            {
                return connection.Table<Currency>().FirstOrDefault(x => x.IdCurrency == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }
        public void Delete(int id)
        {
            try
            {
                var currency = Get(id);
                connection.Delete(currency);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
    }
}
