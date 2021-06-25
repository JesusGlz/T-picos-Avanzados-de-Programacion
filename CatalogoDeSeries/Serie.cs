using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoDeSeries
{
    [Serializable]
   public class Serie
    {

        public int NumCapitulo { get; set; }
        public string Español { get; set; }
        public string Ingles { get; set; }

        public int Temporada { get; set; }
       
        public string Descripcion { get; set; }
        public string Ruta { get; set; }

    }
}
