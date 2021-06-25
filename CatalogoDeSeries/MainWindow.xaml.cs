using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatalogoDeSeries
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lstCapitulos.ItemsSource = null;
            lstCapitulos.ItemsSource = repositorio.lista.ToList();
        }
        SeriesRepository repositorio = new SeriesRepository();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AgregarCap agregarCap = new AgregarCap();
            Serie serie = new Serie();
            agregarCap.DataContext = serie;

            if(agregarCap.ShowDialog()==true)
            {
                repositorio.Agregar(serie);
            }
            else
            {

                DialogResult = true;
            }
            lstCapitulos.ItemsSource = null;
            lstCapitulos.ItemsSource = repositorio.lista.ToList();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem btn = (MenuItem)sender;
            Serie serie = (Serie)btn.CommandParameter;

            EditarCap agregar = new EditarCap();


            agregar.DataContext = serie;

            if (agregar.ShowDialog() == true)
            {
                lstCapitulos.ItemsSource = repositorio.lista.ToList();
                repositorio.Guardar();
                lstCapitulos.ItemsSource = repositorio.lista.ToList();
            }
        }

        private void eliminar_Click(object sender, RoutedEventArgs e)
        {
            MenuItem btn = (MenuItem)sender;

            Serie Capitulo = (Serie)btn.CommandParameter;
            if (MessageBox.Show($"¿Quieres eliminar {Capitulo.Español}?",
                "Guia",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                repositorio.Elminar(Capitulo);
                //se actualiza manualmente porque se utiliza un metodo para
                //llenarlo y no la coleccion completa de elementos
                lstCapitulos.ItemsSource = repositorio.lista.ToList();
            }
        }

    }
}
