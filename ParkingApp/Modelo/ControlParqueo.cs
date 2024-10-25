using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Modelo
{
    [Table(name: "control")]
    public class ControlParqueo
    {
        [Column(name: "codigo")]
        [Key]
        public int? Codigo { get; set; }

        [Column(name: "placa")]
        public string Placa { get; set; }

        [Column(name: "tipo")]
        public int Tipo { get; set; }

        [Column(name: "fechaIngreso")]
        public string FechaIngreso { get; set; }
        [Column(name: "fechaSalida")]
        public string FechaSalida { get; set; }
        [Column(name: "valor")]
        public double Valor { get; set; }
        [Column(name: "minutos")]
        public int Minutos { get; set; }
        [Column(name: "tarifa")]
        public double Tarifa { get; set; }
    }
}
