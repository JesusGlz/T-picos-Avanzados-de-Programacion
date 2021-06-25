using CodeFirst.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.Repositories
{
   public class AgendaRepository
    {
        SQLiteConnection connection = new SQLiteConnection(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/agenda.sql");
        public AgendaRepository()
        {
            connection.CreateTable<Agenda>();
        }
        public List<Agenda> ObtenerLista()
        {
            return new List<Agenda>(connection.Table<Agenda>());
        }
        public void Agregar(Agenda a)
        {
            Agenda nuevo = new Agenda()
            {
                Nombre = a.Nombre,
                Asunto = a.Asunto,
                Estado = true,
                Fecha = a.Fecha
            };
            connection.Insert(nuevo);
        }
        public void Eliminar(Agenda a)
        {
            connection.Delete<Agenda>(a.Id);
        }

        public void Editar(Agenda a)
        {
            Agenda edicion = new Agenda()
            {
                Asunto=a.Asunto,
                Estado=a.Estado,
                Fecha=a.Fecha,
                Nombre=a.Nombre,
                Id=a.Id
            };

            connection.Update(edicion);
        }
       
    }
}
