using CodeFirst.Models;
using CodeFirst.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace CodeFirst.ViewModels
{
    public class AgendarViewNodel : INotifyPropertyChanged
    {
        private string error;
        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Error"));
            }
        }
        private List<Agenda> agenda;

        public List<Agenda> Agenda
        {
            get { return agenda; }
            set
            {
                agenda = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Agenda"));
            }
        }
        private Agenda cita;

        public Agenda Cita
        {
            get { return cita; }
            set
            {
                cita = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cita"));
            }
        }
        public Command NuevoCommand { get; set; }
        public Command<Agenda> EditarCommand { get; set; }
        public Command GuardarCommand { get; set; }
        public Command<Agenda> EliminarCommand { get; set; }
        public Command ActualizarCommand { get; set; }
        public AgendarViewNodel()
        {
            Agenda = App.Repository.ObtenerLista();
            NuevoCommand = new Command(Agregar);
            EditarCommand = new Command<Agenda>(Editar);
            GuardarCommand = new Command(Guardar);
            EliminarCommand = new Command<Agenda>(Eliminar);
            ActualizarCommand = new Command(Actualizar);
        }

        private void Actualizar()
        {
            try
            {
                if (Validar(Cita))
                {
                    App.Repository.Editar(Cita);
                    App.Current.MainPage.Navigation.PopAsync();
                    Agenda = App.Repository.ObtenerLista();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Eliminar(Agenda agenda)
        {
            App.Repository.Eliminar(agenda);
            Agenda = App.Repository.ObtenerLista();
        }

        private void Guardar()
        {
            try
            {
                if (Validar(Cita))
                {
                    App.Repository.Agregar(Cita);
                    App.Current.MainPage.Navigation.PopAsync();
                    Agenda = App.Repository.ObtenerLista();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        EditarView editarView;
        private void Editar(Agenda agenda)
        {
            editarView = new EditarView();
            cita = agenda;
            editarView.BindingContext = this;
            App.Current.MainPage.Navigation.PushAsync(editarView);
        }
        AgregarView agregarView;
        private void Agregar()
        {
            agregarView = new AgregarView();
            Cita = new Agenda();
            agregarView.BindingContext = this;
            Application.Current.MainPage.Navigation.PushAsync(agregarView);
        }




        bool Validar(Agenda a)
        {
            Error = "";
            if (String.IsNullOrWhiteSpace(a.Asunto))
            {
                Error ="El Asunto no puede ir vacio";
            }
            if (a.Fecha.Date.Year < DateTime.Now.Year)
            {
                Error = "La fecha tiene que ser posterior a hoy.";
            }
            return Error=="";
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
