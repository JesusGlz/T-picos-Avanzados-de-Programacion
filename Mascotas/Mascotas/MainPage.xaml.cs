using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Mascotas
{
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        [Obsolete]
        public MainPage()
        {
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom).SetBarItemColor(Color.Black)
            .SetBarSelectedItemColor(Color.AliceBlue);
        }

        
    }
}
