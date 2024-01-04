using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace Proiect_NETMaui.Models
{
     public class MyReservations
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(Rezervare))]
        public int RezervareID { get; set; }

        public Rezervare Rezervare { get; set; }

        [ForeignKey(typeof(Restaurant))]
        public int RestaurantID { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
