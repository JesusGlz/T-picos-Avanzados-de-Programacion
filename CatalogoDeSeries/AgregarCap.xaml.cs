using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace CatalogoDeSeries
{
    /// <summary>
    /// Lógica de interacción para AgregarCap.xaml
    /// </summary>
    public partial class AgregarCap : Window
    {
        public AgregarCap()
        {
            InitializeComponent();
        }

        private void imgCapitulo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Todos los archivos de imagen |*.jpg";
            MemoryStream arch = new MemoryStream();
            if (open.ShowDialog() == true)
            {
                BitmapImage b = new BitmapImage();
                string rut = open.FileName;
                FileStream file = new FileStream(open.FileName, FileMode.Open);
                b.BeginInit();
                b.CacheOption = BitmapCacheOption.OnLoad;
                b.StreamSource = file;
                b.EndInit();
                b.Freeze();
                imgCapitulo.Source = b;
                txtruta.Text = open.FileName;
                file.Close();
            }
            txtruta.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var error = Contenedor.Children.OfType<TextBox>().Where(x => Validation.GetHasError(x)).Select(x => Validation.GetErrors(x)[0].ErrorContent.ToString());
            if (error == null)
            {
                MessageBox.Show("Verifique los errores");
            }
            else
            {

                DialogResult = true;
            }
        }

        
    }
}
