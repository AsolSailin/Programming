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

        private void OpeningBracketBtn_Click(object sender, RoutedEventArgs e)
        {
            TextNumber.Text += (string)((Button)sender).Content;
        }

        private void ClosingBracketBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextNumber.Text.Contains('('))
            {
                TextNumber.Text += (string)((Button)sender).Content;
            }
        }
        private void CommaBtn_Click(object sender, RoutedEventArgs e)
        {

            if (!TextNumber.Text.Contains(','))
            {
                TextNumber.Text += (string)((Button)sender).Content;
            }
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
                TextNumber.Text = Factorial(int.Parse(TextNumber.Text)).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }

        private int Factorial(int n)
        {
            if (n == 1)
                return 1;

            return n * Factorial(n - 1);
        }

        private void PlusMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextNumber.Text = (-(Convert.ToDouble(TextNumber.Text))).ToString();
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
                TextNumber.Text = Math.Round((1 / Convert.ToDouble(TextNumber.Text)), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "1/";
            }
        }

        private void InvBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextNumber.Text = Math.Round((1 / Convert.ToDouble(TextNumber.Text)), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "1/";
            }
        }

        private void PercentBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextNumber.Text = Math.Round((Convert.ToDouble(TextNumber.Text) / 100), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }

        private void SquareRootBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextNumber.Text = Math.Round(Math.Sqrt(Convert.ToDouble(TextNumber.Text)), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "SQRT";
            }
        }
        private void CubicRootBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextNumber.Text = Math.Round(Math.Pow(Convert.ToDouble(TextNumber.Text), 1 / 3f), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }

        private void SquareBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextNumber.Text = Math.Round(Math.Pow(Convert.ToDouble(TextNumber.Text), 2), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }

        private void CubeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextNumber.Text = Math.Round(Math.Pow(Convert.ToDouble(TextNumber.Text), 3), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "Error!";
            }
        }
        private void DegreeOfTenBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextNumber.Text = Math.Round(Math.Pow(10, Convert.ToDouble(TextNumber.Text)), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "10^";
            }
        }

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextNumber.Text = Math.Round(Math.Log10(Convert.ToDouble(TextNumber.Text)), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "LOG";
            }
        }

        private void LnBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextNumber.Text = Math.Round(Math.Log(Convert.ToDouble(TextNumber.Text)), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "LN";
            }
        }

        private void RadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            degreesOrRadians = (string)((RadioButton)sender).Content;
        }

        private static double ConvertDegreesAndRadians(double measurement)
        {
            if (degreesOrRadians == "Degrees")
            {
                return measurement;
            }

            return measurement * (Math.PI / 180);
        }

        private void PiBtn_Click(object sender, RoutedEventArgs e)
        {
            TextNumber.Text = Math.Round(Math.PI, 5).ToString();
        }

        private void SinBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextNumber.Text = Math.Round(Math.Sin(ConvertDegreesAndRadians(Convert.ToDouble(TextNumber.Text))), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "SIN";
            }
        }

        private void CosBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextNumber.Text = Math.Round(Math.Cos(ConvertDegreesAndRadians(Convert.ToDouble(TextNumber.Text))), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "COS";
            }
        }

        private void TanBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextNumber.Text = Math.Round(Math.Tan(ConvertDegreesAndRadians(Convert.ToDouble(TextNumber.Text))), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "TAN";
            }
        }

        private void SinhBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextNumber.Text = Math.Round(Math.Sinh(ConvertDegreesAndRadians(Convert.ToDouble(TextNumber.Text))), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "SINH";
            }
        }

        private void CoshBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextNumber.Text = Math.Round(Math.Cosh(ConvertDegreesAndRadians(Convert.ToDouble(TextNumber.Text))), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "COSH";
            }
        }

        private void TanhBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextNumber.Text = Math.Round(Math.Tanh(ConvertDegreesAndRadians(Convert.ToDouble(TextNumber.Text))), 5).ToString();
            }
            catch
            {
                //Exception
                TextNumber.Text = "TANH";
            }
        }
    }
}
