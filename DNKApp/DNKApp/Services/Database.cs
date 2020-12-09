using DNKApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DNKApp.Services
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<clsInvoice>().Wait();
        }

        public Task<List<clsInvoice>> GetPeopleAsync()
        {
            return _database.Table<clsInvoice>().ToListAsync();
        }

        public Task<int> SavePersonAsync(clsInvoice person)
        {
            return _database.InsertAsync(person);
        }
    }
}
