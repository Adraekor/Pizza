using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Cours.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Cours
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new TraficLights();
            //MainPage = new CalculatorV1();
            //MainPage = new DemoPrism();
            MainPage = new CalculatorV15();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
