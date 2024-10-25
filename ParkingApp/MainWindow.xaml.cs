using ParkingApp.Controlador;
using ParkingApp.Dao;
using ParkingApp.General;
using ParkingApp.Modelo;
using System;
using System.Data.Entity;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ParkingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ControlView controlador;

        public MainWindow()
        {
            DbConfiguration.SetConfiguration(new SQLiteConfiguration());
            controlador = new ControlView();
            DataContext = controlador;

            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!ParkingDAO.ExistePLaca(controlador.Modelo))
            {
                controlador.Modelo.FechaIngreso = DateTime.Now.ToString();
                FechaIni.Text = controlador.Modelo.FechaIngreso;
            }
            else
            {
                ControlParqueo existe = ParkingDAO.ObtDatosPlaca(controlador.Modelo);
                controlador.Modelo.FechaIngreso = existe.FechaIngreso;
                controlador.Modelo.FechaSalida = DateTime.Now.ToString();
                FechaFin.Text = controlador.Modelo.FechaSalida;

                controlador.Modelo.Minutos = int.Parse((DateTime.Parse(controlador.Modelo.FechaSalida) - DateTime.Parse(controlador.Modelo.FechaIngreso)).ToString());
                Tiempo.Text = controlador.Modelo.Minutos.ToString();
            }
        }
    }
}