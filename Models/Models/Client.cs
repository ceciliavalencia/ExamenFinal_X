﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
   public class Client
   {
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string CUI { get; set; }
        public string pais { get; set; }
        public int idRubro { get; set; }
        public double cantidad_donacion { get; set; }

      //  public Type MyProperty { get; set; }
   }
}
