using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_NETMaui.Models
{
    [Table("Review")]
    public class Review
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

       // [MaxLength(500, ErrorMessage = "Comentariul nu poate depăși 500 de caractere.")]
        public string Comentariu { get; set; }

        [Range(0, 5, ErrorMessage = "Ratingul trebuie să fie între 0 și 5")]
        public int Rating { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public Review()
        {
            Data = DateTime.Now;
        }

        [ForeignKey(typeof(Restaurant))]
        public int? RestaurantID { get; set; }
        [ManyToOne(nameof(RestaurantID))]
        public Restaurant? Restaurant { get; set; }
    }

}

