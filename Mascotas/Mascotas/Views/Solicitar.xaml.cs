using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mascotas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Solicitar : ContentPage
    {
        public Solicitar()
        {
            InitializeComponent();
            var razas = new List<string>();
            razas.Add("affenpinscher");
            razas.Add("african");
            razas.Add("airedale");
            razas.Add("akita");
            razas.Add("appenzeller");
            razas.Add("basenji");
            razas.Add("boxer");
            razas.Add("chihuahua");
            razas.Add("doberman");
            razas.Add("husky");
            razas.Add("mexicanhairless");
            pickerr.ItemsSource = razas;
        
        }
    }
}