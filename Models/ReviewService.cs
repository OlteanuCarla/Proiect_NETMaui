using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_NETMaui.Models
{
    public class ReviewService
    {
        private SQLiteConnection _database; // Acesta trebuie să fie un obiect SQLiteConnection inițializat corespunzător

        public ReviewService(SQLiteConnection database)
        {
            _database = database;
        }
        public void ValidareReview(Review review)
        {
            // Validează rating-ul
            if (review.Rating < 0 || review.Rating > 5)
            {
                throw new ValidationException("The rating must be between 0 and 5.");
            }

            // Alte validări dacă este nevoie
        }
    }

}
