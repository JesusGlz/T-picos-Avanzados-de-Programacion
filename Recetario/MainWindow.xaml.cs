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

namespace Recetario
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Models.Recetario Recetario = new Models.Recetario();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Recetario.LoadData();
            lstRecetas.ItemsSource = null;
            lstRecetas.ItemsSource = Recetario.Recetas.ToList();
        }

        private void lstRecetas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstRecetas.SelectedItem != null)
            {
                Editar editar = new Editar();
                editar.ReferenciaJuego = (Juego)lstJuegos.SelectedItem;
                editar.ReferenciaCatalogo = nuevo;
                editar.ShowDialog();
                nuevo.Guardar();
            }
        }
    }
}
