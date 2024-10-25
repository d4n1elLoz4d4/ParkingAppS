using ParkingApp.BaseDatos;
using ParkingApp.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
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
                if (!ExistePLaca(objeto.Placa))
                {
                    objeto.Tipo = 1;
                    objeto.Valor = 0;
                    objeto.Tarifa = 0;
                    objeto.Minutos = 0;

                    context.ControlCarros.AddOrUpdate(objeto);
                    context.SaveChanges();
                }
                else
                {
                    ControlParqueo itemExiste = ObtDatosPlaca(objeto.Placa);

                    objeto.Codigo = itemExiste.Codigo;
                    context.Entry(objeto).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
        public static bool ExistePLaca(string placa)
        {
            bool existe = false;

            using (DataBaseContext context = new DataBaseContext())
            {
                var objeto = context.ControlCarros.FirstOrDefault(x => x.Placa.Equals(placa));

                if (objeto != null)
                    existe = true;
            }

            return existe;
        }
        public static ControlParqueo ObtDatosPlaca(string placa)
        {
            ControlParqueo existe = new ControlParqueo();

            using (DataBaseContext context = new DataBaseContext())
            {
                existe = context.ControlCarros.FirstOrDefault(x => x.Placa.Equals(placa));
            }

            return existe;
        }
        public static Tipo obtDatosTarifa(int tipo)
        {
            Tipo existe = new Tipo();

            using (DataBaseContext context = new DataBaseContext())
            {
                existe = context.Tipos.FirstOrDefault(x => x.Codigo == tipo);
            }

            return existe;
        }
    }
}
