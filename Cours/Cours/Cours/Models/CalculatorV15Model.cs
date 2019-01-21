using System;
using System.Collections.Generic;
using System.Text;

namespace Cours.Models
{
    public sealed class CalculatorV15Model
    {

        private static readonly Lazy<CalculatorV15Model> lazy = new Lazy<CalculatorV15Model>(() => new CalculatorV15Model());

        public static CalculatorV15Model Instance { get { return lazy.Value; } }

        public int FirstValue { get; set; }
        public int SecondValue { get; set; }
        public string Operator { get; set; }

        private CalculatorV15Model()
        {
            FirstValue = 0;
            SecondValue = 0;
            Operator = "";
        }

        public int Compute()
        {
            switch (Operator)
            {
                case "+": return FirstValue + SecondValue;
                case "-": return FirstValue - SecondValue;
                case "*": return FirstValue * SecondValue;
                case "/":
                    try
                    {
                        return FirstValue / SecondValue;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
            }
            throw new Exception();
        }

        public void ResetState()
        {
            FirstValue = 0;
            SecondValue = 0;
            Operator = "";
        }

    }
}
