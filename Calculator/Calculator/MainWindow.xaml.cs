using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string? degreesOrRadians;
        public MainWindow()
        {
            InitializeComponent();
            degreesOrRadians = "Degrees";
        }
        private void EquallyBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextNumber.Text.Contains("SIN(") ||
                    TextNumber.Text.Contains("COS(") ||
                    TextNumber.Text.Contains("TAN(") ||
                    TextNumber.Text.Contains("SINH(") ||
                    TextNumber.Text.Contains("COSH(") ||
                    TextNumber.Text.Contains("TANH(") ||
                    TextNumber.Text.Contains("LN(") ||
                    TextNumber.Text.Contains("LOG(") ||
                    TextNumber.Text.Contains("10^(") ||
                    TextNumber.Text.Contains("SQRT(") ||
                    TextNumber.Text.Contains("1/("))
                {
                    if (TextNumber.Text.EndsWith(')'))
                    {
                        TextNumber.Text = TextNumber.Text[..^1];
                    }
                    TextNumber.Text += ')';
                }
                TextNumber.Text = Math.Round(Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result, 5).ToString();
            }
            catch
            {
                //Exception 
                TextNumber.Text = "Error!";
            }
        }

        private void NumberInput_Click(object sender, RoutedEventArgs e)
        {
            TextNumber.Text += (string)((Button)sender).Content;
        }

        private void OperationInput_Click(object sender, RoutedEventArgs e)
        {
            TextNumber.Text += (string)((Button)sender).Content;
        }
        private void CommaBtn_Click(object sender, RoutedEventArgs e)
        {
            TextNumber.Text += (string)((Button)sender).Content;
        }

        private void OpeningBracketBtn_Click(object sender, RoutedEventArgs e)
        {
            TextNumber.Text += (string)((Button)sender).Content;
        }

        private void ClosingBracketBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextNumber.Text.Contains('('))
                TextNumber.Text += (string)((Button)sender).Content;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextNumber.Text.Length > 0)
                TextNumber.Text = TextNumber.Text[..^1]; //.Substring(0, TextNumber.Text.Length - 1);
        }
        private void CE()
        {
            TextNumber.Text = "";
        }

        private void CBtn_Click(object sender, RoutedEventArgs e)
        {
            CE();
        }

        private void CEBtn_Click(object sender, RoutedEventArgs e)
        {
            CE();
        }

        private void ModBtn_Click(object sender, RoutedEventArgs e)
        {
            TextNumber.Text += "%";
        }

        private void DegreeBtn_Click(object sender, RoutedEventArgs e)
        {
            TextNumber.Text += "^";
        }

        private void RootBtn_Click(object sender, RoutedEventArgs e)
        {
            TextNumber.Text += "~";
        }

        private void FactorialBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(int.Parse(TextNumber.Text) >= 0)
                {
                    TextNumber.Text = Factorial(int.Parse(TextNumber.Text)).ToString();
                }
                else
                {
                    TextNumber.Text = "Error!";
                }
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }

        private int Factorial(int n)
        {
            if (n == 1 || n == 0)
                return 1;

            return n * Factorial(n - 1);
        }

        private void PlusMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextNumber.Text = (-(Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result)).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }

        private void OneDividedByXBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextNumber.Text == "")
                    TextNumber.Text = "1/(";
                else
                    TextNumber.Text = Math.Round((1 / Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }

        private void InvBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextNumber.Text == "")
                    TextNumber.Text = "1/(";
                else
                    TextNumber.Text = Math.Round((1 / Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }

        private void PercentBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextNumber.Text == "")
                TextNumber.Text = "Error!";
            else
                TextNumber.Text = Math.Round((Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result / 100), 5).ToString();
        }

        private void SquareRootBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextNumber.Text == "")
                    TextNumber.Text = "SQRT(";
                else
                    TextNumber.Text = Math.Round(Math.Sqrt(Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }
        private void CubicRootBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextNumber.Text == "")
                TextNumber.Text = "Error!";
            else
                TextNumber.Text = Math.Round(Math.Pow(Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result, 1 / 3f), 5).ToString();
        }

        private void SquareBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextNumber.Text == "")
                TextNumber.Text = "Error!";
            else
                TextNumber.Text = Math.Round(Math.Pow(Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result, 2), 5).ToString();
        }

        private void CubeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextNumber.Text == "")
                TextNumber.Text = "Error!";
            else
                TextNumber.Text = Math.Round(Math.Pow(Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result, 3), 5).ToString();
        }
        private void DegreeOfTenBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextNumber.Text == "")
                    TextNumber.Text = "10^(";
                else
                    TextNumber.Text = Math.Round(Math.Pow(10, Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextNumber.Text == "")
                    TextNumber.Text = "LOG(";
                else
                    TextNumber.Text = Math.Round(Math.Log10(Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }

        private void LnBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextNumber.Text == "")
                    TextNumber.Text = "LN(";
                else
                    TextNumber.Text = Math.Round(Math.Log(Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }

        private void RadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            degreesOrRadians = (string)((RadioButton)sender).Content;
        }

        private static double ConvertDegreesAndRadians(double measurement)
        {
            if (degreesOrRadians == "Degrees")
                return measurement;

            return measurement * (Math.PI / 180);
        }

        private void PiBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextNumber.Text == "")
                TextNumber.Text = Math.Round(Math.PI, 5).ToString();
            else 
                TextNumber.Text = Math.Round((Convert.ToDouble(TextNumber.Text) * Math.PI), 5).ToString();
        }

        private void SinBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextNumber.Text == "")
                    TextNumber.Text = "SIN(";
                else
                    TextNumber.Text = Math.Round(Math.Sin(ConvertDegreesAndRadians(Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result)), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }

        private void CosBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextNumber.Text == "")
                    TextNumber.Text = "COS(";
                else
                    TextNumber.Text = Math.Round(Math.Cos(ConvertDegreesAndRadians(Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result)), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }

        private void TanBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextNumber.Text == "")
                    TextNumber.Text = "TAN(";
                else
                    TextNumber.Text = Math.Round(Math.Tan(ConvertDegreesAndRadians(Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result)), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }

        private void SinhBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextNumber.Text == "")
                    TextNumber.Text = "SINH(";
                else
                    TextNumber.Text = Math.Round(Math.Sinh(ConvertDegreesAndRadians(Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result)), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }

        private void CoshBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextNumber.Text == "")
                    TextNumber.Text = "COSH(";
                else
                    TextNumber.Text = Math.Round(Math.Cosh(ConvertDegreesAndRadians(Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result)), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }

        private void TanhBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextNumber.Text == "")
                    TextNumber.Text = "TANH(";
                else
                    TextNumber.Text = Math.Round(Math.Tanh(ConvertDegreesAndRadians(Dangl.Calculator.Calculator.Calculate(TextNumber.Text).Result)), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }
    }
}
