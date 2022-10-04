using OctoberDemo.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OctoberDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //List page added as a navigation page

            MainPage = new NavigationPage(new ListPage());
        }

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
