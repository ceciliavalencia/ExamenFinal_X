using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
   public  class Calculos
   {
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public double Cantidad { get; set; }
        public string Rubro { get; set; }
        public double Porcentaje { get; set; }
        public int idRubro { get; set; }
    }
}
