using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CodeFirst.Models
{
   public class Agenda : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int id;
        private string nombre;
        private string asunto;
        private bool estado;
        private DateTime fecha;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; } 
            set
            {
                id = value;
                Lanzar();
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                Lanzar();
            }
        }
        public string Asunto
        {
            get { return asunto; }
            set
            {
                asunto = value;
                Lanzar();
            }
        }
        public bool Estado
        {
            get { return estado; }
            set
            {
                if (fecha > DateTime.Now.Date)
                {
                    //Vigente
                    estado = true;
                }
                else
                {
                    //No vigente
                    estado = false;
                }
                Lanzar();
            }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                fecha = value;
                Lanzar();
            }
        }
        public void Lanzar([CallerMemberName] String propiedad = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }
    }
}
