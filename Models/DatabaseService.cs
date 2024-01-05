using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_NETMaui.Models
{
    class DatabaseService
    {
        private SQLiteConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Review>(); // Asigură-te că ai creat tabela Review în baza de date
        }

        public SQLiteConnection GetConnection()
        {
            return _database;
        }
    }
}
