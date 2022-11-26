using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSMAGA_ZALICZENIE.Models
{
    public class AdminModel
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string uname { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string pass { get; set; }

    }
}