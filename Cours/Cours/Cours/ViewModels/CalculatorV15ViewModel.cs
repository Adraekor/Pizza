using Prism.Mvvm;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

using Cours.Models;

namespace Cours.ViewModels
{
    class CalculatorV15ViewModel : BindableBase
    {

        private string _displayTop = "";
        public string DisplayTop
        {
            get { return _displayTop; }
            set { SetProperty(ref _displayTop, value); }
        }

        private string _displayBot = "";
        public string DisplayBot
        {
            get { return _displayBot; }
            set { SetProperty(ref _displayBot, value); }
        }

        public DelegateCommand<object> CommandButtonNumber { get; private set; }
        public DelegateCommand<object> CommandButtonOperator { get; private set; }
        public DelegateCommand CommandButtonEqual { get; private set; }
        public DelegateCommand CommandButtonC { get; private set; }

        public CalculatorV15ViewModel()
        {

            CommandButtonNumber = new DelegateCommand<object>(AddNumber);
            CommandButtonOperator = new DelegateCommand<object>(AddOperator, CanAddOperator).ObservesProperty(() => DisplayTop).ObservesProperty(() => DisplayBot);
            CommandButtonEqual = new DelegateCommand(Equal, CanDoEqual).ObservesProperty(() => DisplayTop).ObservesProperty(() => DisplayBot);
            CommandButtonC = new DelegateCommand(Erase);
        }

        private bool CanAddOperator(object arg)
        {
            if (DisplayTop == "" && DisplayBot != "")
                return true;

            return false;
        }

        private void AddOperator(object op)
        {
            CalculatorV15Model.Instance.FirstValue = Int32.Parse(DisplayBot);
            CalculatorV15Model.Instance.Operator = (string)op;
            DisplayTop = DisplayBot + " " + (string)op;
            DisplayBot = "";
        }

        private void Erase()
        {
            DisplayBot = "";
            DisplayTop = "";
            CalculatorV15Model.Instance.ResetState();
        }

        private void AddNumber(object number)
        {
            DisplayBot += (string)number;
        }

        private bool CanDoEqual()
        {
            if (DisplayBot != "" && DisplayTop != "")
                return true;

            return false;
        }

        private void Equal()
        {
            CalculatorV15Model.Instance.SecondValue = Int32.Parse(DisplayBot);
            try
            {
                DisplayBot = "" + CalculatorV15Model.Instance.Compute();
                DisplayTop = "";
                CalculatorV15Model.Instance.ResetState();

            }
            catch(Exception ex)
            {

            }
        }
    }
}
