using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRentaDeBarcos
{
    internal class Barco
    {
        public int NumBarco { get; set; }
        public int propietario { get; set; }
        public string nombre { get; set; }
        public string modelo { get; set; }
        public int anio { get; set; }
        public int largo_Pies { get; set; }
        public float tarifaRenta { get; set; }
        public int capacidad { get; set; }
        public int ocupado { get; set; }
    }
}
