using ParkingApp.Dao;
using ParkingApp.Interface;
using ParkingApp.Modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ParkingApp.Controlador
{
    public class ControlControlador: ViewModelBase,IViews
    {
        private readonly DelegateCommand _procesar;
        private readonly DelegateCommand _clickenter;
        private ControlParqueo modelo;

        #region Usados en la UI
        public ICommand pProcesar => _procesar;
        public ICommand pEnter => _clickenter;
        #endregion

        public ControlControlador()
        {
            this.ControlModelo = new ControlParqueo();
            _procesar = new DelegateCommand(Procesar);
            _clickenter = new DelegateCommand(Enter);
        }

        public ControlParqueo ControlModelo
        {
            get { return modelo; }
            set { SetProperty(ref modelo, value); }
        }

        public void Limpíar(object commandParameter)
        {
            throw new NotImplementedException();
        }

        public void Procesar(object commandParameter)
        {
            ParkingDAO.pGuardarParqueo(ControlModelo);

            MessageBox.Show("Proceso Terminado");

            Limpiar(null);
        }
        public void Enter(object commandParameter)
        {
            string placa = commandParameter.ToString(); 

            if (!ParkingDAO.ExistePLaca(placa))
            {
                ControlModelo.FechaIngreso = DateTime.Now.ToString();
            }
            else
            {
                ControlParqueo existe = ParkingDAO.ObtDatosPlaca(placa);

                ControlModelo.FechaIngreso = existe.FechaIngreso;
                ControlModelo.FechaSalida = DateTime.Now.ToString();

                DateTime FechaSalida = DateTime.Parse(ControlModelo.FechaSalida);
                DateTime FechaIngreso = DateTime.Parse(ControlModelo.FechaIngreso);

                TimeSpan restaFechas = FechaSalida - FechaIngreso;
                ControlModelo.Minutos = restaFechas.TotalMinutes;

                Tipo tarifa = ParkingDAO.obtDatosTarifa(1);
                ControlModelo.Valor = ((ControlModelo.Minutos / 60) * tarifa.Tarifa);

                ControlModelo.Tarifa = tarifa.Tarifa;
            }
        }

        public void Limpiar(object commandParameter)
        {
            this.ControlModelo = new ControlParqueo();
        }
    }
}
