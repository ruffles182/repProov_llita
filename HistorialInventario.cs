using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace REPORTE_WPF
{
    internal class HistorialInventario
    {
        public string producto { get; set; }
        public DateTime fecha { get; set; }
        public int cantidadAnterior { get; set; }
        public int cantidad { get; set; }
        public string descripcion { get; set; }
        public float costoUnitario { get; set; }
        public float total { get; set; }
        public string codigo { get; set; }
        public string tMovimiento { get; set; }
        public float tPagar { get; set; }


    }
}
