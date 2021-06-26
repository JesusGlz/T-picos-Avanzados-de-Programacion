using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Mascotas.ViewModels
{
   public class DatosViewModels:INotifyPropertyChanged
    {

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;

                Actualizar();
            }
        }
        private string error;

        public string Error
        {
            get { return error; }
            set { error = value;

                Actualizar();
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value;

                Actualizar();
            }
        }

       
        public Command SubmitCommand { get; set; }

        public DatosViewModels()
        {
            
            SubmitCommand = new Command(Enviar);
        }

        private void Enviar(object obj)
        {
            Error = "";
            if(string.IsNullOrEmpty(Nombre))
            {
                Error = "El campo del nombre es obligatorio";
            }
            if (string.IsNullOrEmpty(Email))
            {
                Error = "El campo del Email es obligatorio";
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void Actualizar(string nombre = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
    }
}
