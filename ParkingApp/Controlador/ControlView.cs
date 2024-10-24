using ParkingApp.Interface;
using ParkingApp.Modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkingApp.Controlador
{
    public class ControlView: ViewModelBase,IViews
    {
        private readonly DelegateCommand _procesar;

        public ControlView()
        {
            this.Modelo = new Control();
            _procesar = new DelegateCommand(Procesar);
        }

        public Control Modelo { get; set; }
        public ICommand pProcesar => _procesar;

        public void Limpíar(object commandParameter)
        {
            throw new NotImplementedException();
        }

        public void Procesar(object commandParameter)
        {
            Control nuevo = new Control();
            nuevo.Placa = Modelo.Placa;
            nuevo.FechaIngreso = DateTime.Now.ToString();
        }
    }
}
