using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPORTE_WPF
{
    internal class ProductoBuscado
    {
        public string nombre { get; set; }
        public string id { get; set; }

        public override string ToString()
        {
            return id;
        }
    }
}
