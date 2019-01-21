using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cours
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //var label = new Label { Text="Welcome to Xamarin.Forms",
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.CenterAndExpand };
            //var stackLayout = new StackLayout();
            //stackLayout.Children.Add(label);
            //Content = stackLayout;
            
        }

        public void OnButtonClicked(object sender, EventArgs args)
        {
            label.Text = "Coucou";
        }
    }
}
