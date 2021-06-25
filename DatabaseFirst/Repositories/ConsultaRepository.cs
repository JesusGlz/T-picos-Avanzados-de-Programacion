using DatabaseFirst.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst.Repositories
{
   public class ConsultaRepository
    {
        SQLiteConnection connection = new SQLiteConnection(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/consultorio.sql");
        public ConsultaRepository()
        {
            connection.CreateTable<Medicion>();
        }
        public void Agregar(Medicion m)
        {
            Medicion agregarr = new Medicion()
            {
                Diastolica = m.Diastolica,
                Fecha = m.Fecha,
                Pulso = m.Pulso,
                Sistolica = m.Sistolica
            };
            connection.Insert(agregarr);
        }
        public void Editar(Medicion m)
        {
            Medicion editarr = new Medicion()
            {
                Diastolica = m.Diastolica,
                Fecha = m.Fecha,
                Id = m.Id,
                Pulso = m.Pulso,
                Sistolica = m.Sistolica
            };
            connection.Update(editarr);
        }
        public List<Medicion> Lista()
        {
            return new List<Medicion>(connection.Table<Medicion>());
        }
        public void Eliminar(Medicion m)
        {
            connection.Delete<Medicion>(m.Id);
        }
    }
}
