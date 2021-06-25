using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst.Models
{
    public class Medicion : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DateTime fecha;
        private int sistolica;
        private int diastolica;
        private int pulso;
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                Notificar();
            }
        }
        public void Notificar([CallerMemberName] String propiedad = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }
        public int Pulso
        {
            get { return pulso; }
            set
            {
                pulso = value;
                Notificar();
            }
        }


        public int Diastolica
        {
            get { return diastolica; }
            set
            {
                diastolica = value;
                Notificar();
            }
        }


        public int Sistolica
        {
            get { return sistolica; }
            set
            {
                sistolica = value;
                Notificar();
            }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                fecha = value;
                Notificar();
            }
        }


    }
}
