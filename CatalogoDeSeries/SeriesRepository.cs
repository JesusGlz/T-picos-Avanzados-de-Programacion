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
    public class SeriesRepository
    {
        public ObservableCollection<Serie> lista { get; set; } = new ObservableCollection<Serie>();
        public void Guardar()
        {
            FileStream archivo = File.Create("series.char");
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(archivo, lista);
            archivo.Close();
        }
        public void Elminar(Serie s)
        {
            File.Delete($"{Directory.GetCurrentDirectory()}\\Portadas\\{s.NumCapitulo}.jpg");
            lista.Remove(s);
            Guardar();
        }
        public void Agregar(Serie nuevo)
        {

            if (!Directory.Exists($"{Directory.GetCurrentDirectory()}\\Portadas"))

                Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\Portadas");

            File.Copy(nuevo.Ruta, $"{Directory.GetCurrentDirectory()}\\Portadas\\{nuevo.NumCapitulo}.jpg", true);
            lista.Add(nuevo);
            Guardar();
        }
        public void Editar(Serie s)
        {
            Elminar(s);
            Agregar(s);
        }
        public SeriesRepository()
        {
            Cargar();
        }
        public void Cargar()
        {
            if (File.Exists("series.char"))
            {
                FileStream archivo = File.OpenRead("series.char");
                BinaryFormatter bf = new BinaryFormatter();
                lista = (ObservableCollection<Serie>)bf.Deserialize(archivo);
                archivo.Close();
            }
        }
    }
}
