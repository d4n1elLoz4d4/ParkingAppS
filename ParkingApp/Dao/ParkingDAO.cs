using ParkingApp.BaseDatos;
using ParkingApp.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Dao
{
    public class ParkingDAO
    {
        public static void pGuardarParqueo(ControlParqueo objeto)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                context.ControlCarros.Add(objeto);
                context.SaveChanges();
            }
        }
        public static bool ExistePLaca(ControlParqueo control)
        {
            bool existe = false;

            using (DataBaseContext context = new DataBaseContext())
            {
                var objeto = context.ControlCarros.FirstOrDefault(x => x.Placa.Equals(control.Placa));

                if (objeto != null)
                    existe = true;
            }

            return existe;
        }
        public static ControlParqueo ObtDatosPlaca(ControlParqueo control)
        {
            ControlParqueo existe = new ControlParqueo();

            using (DataBaseContext context = new DataBaseContext())
            {
                existe = context.ControlCarros.FirstOrDefault(x => x.Placa.Equals(control.Placa));
            }

            return existe;
        }
    }
}
