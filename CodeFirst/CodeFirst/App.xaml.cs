using CodeFirst.Repositories;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodeFirst
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
        public static AgendaRepository Repository { get; set; } = new AgendaRepository();
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
