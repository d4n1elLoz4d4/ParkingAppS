using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Modelo
{
    [Table(name: "tipo")]
    public class Tipo
    {
        [Column(name: "codigo")]
        [Key]
        public int? Codigo { get; set; }
        [Column(name: "descripcion")]
        public string Descripcion { get; set; }
        [Column(name: "tarifa")]
        public double? Tarifa { get; set; }
    }
}
