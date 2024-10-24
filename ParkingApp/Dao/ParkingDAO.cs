using ParkingApp.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ParkingApp.Dao
{
    public class ParkingDAO
    {
        public static void pGuardarTipoObjeto(Control objeto)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                context.Control.Add(objeto);
                context.SaveChanges();
            }
        }
    }
}
