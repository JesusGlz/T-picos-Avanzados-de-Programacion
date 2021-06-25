using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Recetario.Models
{
    public class Recetario
    {

        public List<Receta> Recetas { get; set; }

        public Recetario()
        {
            LoadData();
        }

        public void Insert(Receta r)
        {
            if (Validate(r))
            {
                Recetas.Add(r);
                SaveChanges();
                DataChanged?.Invoke();
            }
        }

        public void Update(Receta original, Receta copy)
        {
            if (Validate(copy))
            {
                var position = Recetas.IndexOf(original);
                Recetas[position] = copy;
                SaveChanges();
                DataChanged?.Invoke();
            }
        }

        public void Delete(Receta r)
        {
            if (Recetas.Contains(r))
            {
                Recetas.Remove(r);
                SaveChanges();
                DataChanged?.Invoke();
            }
        }


        public bool Validate(Receta r)
        {
            StringBuilder builder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(r.Nombre))
            {
                builder.AppendLine("• Escriba el nombre de la receta");
            }
            if (string.IsNullOrWhiteSpace(r.Ingredientes))
            {
                builder.AppendLine("• Escriba la lista de ingredientes de la receta");
            }
            if (string.IsNullOrWhiteSpace(r.Procedimiento))
            {
                builder.AppendLine("• Escriba el procedimiento de elaboración de la receta ");
            }


            if (builder.Length > 0)
            {
                throw new Exception(builder.ToString());
            }

            return true;
        }

        public event Action DataChanged;

        public void SaveChanges()
        {
            var file = File.Create(nameof(Recetario));
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(file, Recetas);
            file.Close();
        }

        public void LoadData()
        {
            try
            {
                var file = File.OpenRead(nameof(Recetario));
                BinaryFormatter deserializer = new BinaryFormatter();
                Recetas = (List<Receta>)deserializer.Deserialize(file);
                file.Close();
            }
            catch
            {
                Recetas = new List<Receta>();
            }
        }
    }
}
