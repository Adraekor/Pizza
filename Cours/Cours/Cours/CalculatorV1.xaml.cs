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
	public partial class CalculatorV1 : ContentPage
	{

        private int _topValue;
        private string _op;

		public CalculatorV1 ()
		{
			InitializeComponent ();
            _topValue = 0;
            _op = "";
		}

        public void OnClickButtonNumber(object sender, EventArgs eventArgs)
        {
            displayBot.Text += ((Button)sender).Text;
        }

        public void OnClickButtonOperator(object sender, EventArgs eventArgs)
        {
            if (displayTop.Text == "" && displayBot.Text != "")
            {
                _topValue = Int32.Parse(displayBot.Text);
                _op = ((Button)sender).Text;
                displayTop.Text = displayBot.Text;
                displayTop.Text += " " + _op;
                displayBot.Text = "";
            }
        }

        public void OnClickButtonEqual(object sender, EventArgs eventArgs)
        {
            if(_op != "" && displayBot.Text != "")
            {
                switch(_op)
                {
                    case "+": displayBot.Text = "" + (_topValue + Int32.Parse(displayBot.Text)); break;
                    case "-": displayBot.Text = "" + (_topValue - Int32.Parse(displayBot.Text)); break;
                    case "*": displayBot.Text = "" + (_topValue * Int32.Parse(displayBot.Text)); break;
                    case "/":
                        if (Int32.Parse(displayBot.Text) == 0)
                            return;
                        
                        displayBot.Text = "" + (_topValue / Int32.Parse(displayBot.Text));
                        break;
                }

                _op = "";
                _topValue = 0;
                displayTop.Text = "";
            }
        }

        public void OnClickButtonC(object sender, EventArgs eventArgs)
        {
            displayTop.Text = "";
            displayBot.Text = "";
            _topValue = 0;
            _op = "";
        }
    }
}