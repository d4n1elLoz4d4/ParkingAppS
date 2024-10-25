using ParkingApp.Dao;
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
        private ControlParqueo modelo;

        public ControlView()
        {
            this.Modelo = new ControlParqueo();
            _procesar = new DelegateCommand(Procesar);
        }

        public ControlParqueo Modelo
        {
            get { return modelo; }
            set { SetProperty(ref modelo, value); }
        }
        public ICommand pProcesar => _procesar;

        public void Limpíar(object commandParameter)
        {
            throw new NotImplementedException();
        }

        public void Procesar(object commandParameter)
        {
            Modelo.Tipo = 1;

            ParkingDAO.pGuardarParqueo(Modelo);
        }
    }
}
