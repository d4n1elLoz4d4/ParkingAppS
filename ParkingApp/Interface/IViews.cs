using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Interface
{
    public interface IViews
    {
        void Procesar(object commandParameter);
        void Limpíar(object commandParameter);
    }
}
