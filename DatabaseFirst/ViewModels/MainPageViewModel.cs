using DatabaseFirst.Models;
using DatabaseFirst.Repositories;
using DatabaseFirst.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DatabaseFirst.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        ConsultaRepository repo = new ConsultaRepository();
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Medicion> lista;

        public List<Medicion> Lista
        {
            get { return lista; }
            set
            {
                lista = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Lista"));
            }
        }
        private Medicion consulta;

        public Medicion Consulta
        {
            get { return consulta; }
            set
            {
                consulta = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Consulta"));
            }
        }
        public Command NuevoCommand { get; set; }
        public Command<Medicion> EditarCommand { get; set; }
        public Command GuardarCommand { get; set; }
        public Command ActualizarCommand { get; set; }
        public Command<Medicion> EliminarCommand { get; set; }
        public MainPageViewModel()
        {
            
            Lista = repo.Lista();
            NuevoCommand = new Command(Nuevo);
            EditarCommand = new Command<Medicion>(Editar);
            GuardarCommand = new Command(Guardar);
            ActualizarCommand = new Command(Actualizar);
            EliminarCommand = new Command<Medicion>(Eliminar);
        }

        private void Eliminar(Medicion obj)
        {
            repo.Eliminar(obj);
            Lista = repo.Lista();
        }

        private void Actualizar(object obj)
        {
        }

        private void Guardar(object obj)
        {
        }

        private void Editar(Medicion obj)
        {
        }

        private void Nuevo(object obj)
        {
            Agregar addd = new Agregar();
            addd.Show();
            App.Current.MainWindow.Close();
        }
    }
}
