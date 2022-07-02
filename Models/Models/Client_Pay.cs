using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Client_Pay
    {
        public int idCalculo { get; set; }
        public int idCliente { get; set; }
        public int idRubro { get; set; }
        public string impuesto { get; set; }
        public string descripcion { get; set; }
        public double total { get; set; }
      
    }
}
