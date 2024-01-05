using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_NETMaui.Models
{
    [Table("Profile")]
    public class Profile
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Prenume { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }
        public string NrTelefon { get; set; }

       // public string? CodPromotional { get; set; }

    }
}

