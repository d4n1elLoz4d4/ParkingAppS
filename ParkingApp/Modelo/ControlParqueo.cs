using ParkingApp.Interface;
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
    public class ControlParqueo: ViewModelBase
    {
        private string placa;
        private string fechaIngreso;
        private string fechaSalida;
        private int tipo;
        private double? valor;
        private double? minutos;
        private double? tarifa;

        [Column(name: "codigo")]
        [Key]
        public int? Codigo { get; set; }

        [Column(name: "placa")]
        public string Placa
        {
            get { return placa; }
            set
            {
                SetProperty(ref placa, value);
            }
        }

        [Column(name: "tipo")]
        public int Tipo
        {
            get { return tipo; }
            set
            {
                SetProperty(ref tipo, value);
            }
        }

        [Column(name: "fechaIngreso")]
        public string FechaIngreso
        {
            get { return fechaIngreso; }
            set
            {
                SetProperty(ref fechaIngreso, (DateTime.Parse(value)).ToString("dd/MM/yyyy HH:mm:ss"));
            }
        }
        [Column(name: "fechaSalida")]
        public string FechaSalida {
            get { return fechaSalida; }
            set { SetProperty(ref fechaSalida, value); }
        }
        [Column(name: "valor")]
        public double? Valor
        {
            get { return valor; }
            set
            {
                SetProperty(ref valor, value);
            }
        }
        [Column(name: "minutos")]
        public double? Minutos
        {
            get { return minutos; }
            set
            {
                SetProperty(ref minutos, value);
            }
        }
        [Column(name: "tarifa")]
        public double? Tarifa
        {
            get { return tarifa; }
            set
            {
                SetProperty(ref tarifa, value);
            }
        }
    }
}
