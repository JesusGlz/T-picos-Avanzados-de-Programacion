using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recetas
{
   public class Receta
    {
        public string Nombre { get; set; }
        public string Ingredientes { get; set; }
        public int TiempoCocinar { get; set; }
        public string Procedimiento { get; set; }
    }
}
