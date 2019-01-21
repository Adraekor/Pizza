using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cours
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TraficLights : ContentPage
	{
		public TraficLights ()
		{
			InitializeComponent ();
		}

        public void OnRedClicked(object sender, EventArgs args)
        {
            RedLight.BackgroundColor = Color.Red;
            YellowLight.BackgroundColor = Color.Transparent;
            GreenLight.BackgroundColor = Color.Transparent;

            RedButton.IsEnabled = false;
            YellowButton.IsEnabled = false;
            GreenButton.IsEnabled = true;
        }

        public void OnYellowClicked(object sender, EventArgs args)
        {
            RedLight.BackgroundColor = Color.Transparent;
            YellowLight.BackgroundColor = Color.Yellow;
            GreenLight.BackgroundColor = Color.Transparent;

            RedButton.IsEnabled = true;
            YellowButton.IsEnabled = false;
            GreenButton.IsEnabled = false;
        }

        public void OnGreenClicked(object sender, EventArgs args)
        {
            RedLight.BackgroundColor = Color.Transparent;
            YellowLight.BackgroundColor = Color.Transparent;
            GreenLight.BackgroundColor = Color.Green;

            RedButton.IsEnabled = false;
            YellowButton.IsEnabled = true;
            GreenButton.IsEnabled = false;
        }
    }
}