using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SSMAGA_ZALICZENIE.Models
{
    public class RezerwacjeModel
    {
        [Key]
        public int ID_REZ { get; set; }
        public DateOnly DATA_POCZ { get; set; }
        public DateOnly DATA_KON { get; set; }
        public OfertaModel Oferta { get; set; }
    }
}

