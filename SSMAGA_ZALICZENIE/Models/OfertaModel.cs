using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSMAGA_ZALICZENIE.Models
{
    public class OfertaModel
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Imie { get; set; }
        public int Il_Os { get; set; }
        [Column(TypeName = "text")]
        public string Opis { get; set; }
        public decimal Cena { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Zdjecie { get; set; }
        public ICollection<RezerwacjeModel> Rezerwacje { get; set; }

    }
}