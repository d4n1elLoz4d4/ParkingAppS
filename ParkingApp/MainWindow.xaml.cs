using ParkingApp.Controlador;
using ParkingApp.Dao;
using ParkingApp.General;
using ParkingApp.Modelo;
using System;
using System.Data.Entity;
using System.Globalization;
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
        private ControlControlador controlador;

        public MainWindow()
        {
            DbConfiguration.SetConfiguration(new SQLiteConfiguration());

            controlador = new ControlControlador();
            DataContext = controlador;

            InitializeComponent();
        }
    }
}