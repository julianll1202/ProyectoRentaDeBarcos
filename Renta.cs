using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRentaDeBarcos
{
    internal class Renta
    {
        public int NumRenta { get; set; }
        public DateTime fechaRenta { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int Cliente { get; set; }
        public int Barco { get; set; }
    }
}
