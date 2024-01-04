using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Proiect_NETMaui.Models;

namespace Proiect_NETMaui.Data
{
    public class RestaurantDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public RestaurantDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Restaurant>().Wait();
            _database.CreateTableAsync<Review>().Wait();
        }
        public Task<List<Restaurant>> GetRestaurantAsync()
        {
            return _database.Table<Restaurant>().ToListAsync();
        }
        public Task<Restaurant> GetRestaurantAsync(int id)
        {
            return _database.Table<Restaurant>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveRestaurantAsync(Restaurant restaurant)
        {
            if (restaurant.ID != 0)
            {
                return _database.UpdateAsync(restaurant);
            }
            else
            {
                return _database.InsertAsync(restaurant);
            }
        }
        public Task<int> DeleteRestaurantAsync(Restaurant restaurant)
        {
            return _database.DeleteAsync(restaurant);
        }
        public Task<List<Review>> GetReviewAsync()
        {
            return _database.Table<Review>().ToListAsync();
        }
        public Task<Review> GetReviewAsync(int id)
        {
            return _database.Table<Review>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }

        public Task<int> SaveReviewAsync(Review review)
        {
            if (review.ID != 0)
            {
                return _database.UpdateAsync(review);
            }
            else
            {
                return _database.InsertAsync(review);
            }
        }
        public Task<int> DeleteReviewAsync(Review review)
        {
            return _database.DeleteAsync(review);
        }
        
    }
}
