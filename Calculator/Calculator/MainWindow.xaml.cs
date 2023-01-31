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
        private static string degreesOrRadians;
        public MainWindow()
        {
            InitializeComponent();
            degreesOrRadians = "Degrees";
        }

        private void NumberInput_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            TextNumber.Text += btn.Content.ToString();
        }

        private void OperationInput_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            TextNumber.Text += btn.Content.ToString();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextNumber.Text.Length > 0)
                TextNumber.Text = TextNumber.Text[..^1]; //.Substring(0, TextNumber.Text.Length - 1);
        }

        private void CBtn_Click(object sender, RoutedEventArgs e)
        {
            CE();
        }

        private void CEBtn_Click(object sender, RoutedEventArgs e)
        {
            CE();
        }

        private void CE()
        {
            TextNumber.Text = "";
        }

        private void CommaBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (!TextNumber.Text.Contains(','))
            {
                var btn = (Button)sender;
                TextNumber.Text += btn.Content.ToString();
            }
        }

        private void PlusMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            double number = Convert.ToDouble(TextNumber.Text);
            TextNumber.Text = (-number).ToString();
        }

        private void OneDividedByXBtn_Click(object sender, RoutedEventArgs e)
        {
            double res = 1 / Convert.ToDouble(TextNumber.Text);
            TextNumber.Text = res.ToString();
        }

        private void PercentBtn_Click(object sender, RoutedEventArgs e)
        {
            double res = Convert.ToDouble(TextNumber.Text) / 100;
            TextNumber.Text = res.ToString();
        }

        private void SquareRootBtn_Click(object sender, RoutedEventArgs e)
        {
            double res = Math.Sqrt(Convert.ToDouble(TextNumber.Text));
            TextNumber.Text = res.ToString();
        }

        private void EquallyBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var expression = TextNumber.Text;
                TextNumber.Text = Dangl.Calculator.Calculator.Calculate(expression).Result.ToString();
                //Result();
            }
            catch 
            {
                //Exception 
                TextNumber.Text = "Error!";
            }
        }

        private void OpeningBracketBtn_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            TextNumber.Text += btn.Content.ToString();
        }

        private void ClosingBracketBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextNumber.Text.Contains('('))
            {
                var btn = (Button)sender;
                TextNumber.Text += btn.Content.ToString();
            }
        }

        private void SquareBtn_Click(object sender, RoutedEventArgs e)
        {
            double res = Math.Pow(Convert.ToDouble(TextNumber.Text), 2);
            TextNumber.Text = res.ToString();
        }

        private void DegreeBtn_Click(object sender, RoutedEventArgs e)
        {
            TextNumber.Text += "^";
        }

        private void CubeBtn_Click(object sender, RoutedEventArgs e)
        {
            double res = Math.Pow(Convert.ToDouble(TextNumber.Text), 3);
            TextNumber.Text = res.ToString();
        }

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {
            double res = Math.Log10(Convert.ToDouble(TextNumber.Text));
            TextNumber.Text = res.ToString();
        }

        private void FactorialBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int res = Factorial(int.Parse(TextNumber.Text));
                TextNumber.Text = res.ToString();
            }
            catch 
            {
                //Exception
                TextNumber.Text = "Undefined";
            }
        }

        private int Factorial(int n)
        {
            if (n == 1) 
                return 1;

            return n * Factorial(n - 1);
        }

        private void RootBtn_Click(object sender, RoutedEventArgs e)
        {
            TextNumber.Text += "~";
        }

        private void CubicRootBtn_Click(object sender, RoutedEventArgs e)
        {
            double res = Math.Round(Math.Pow(Convert.ToDouble(TextNumber.Text), 1/3f), 5);
            TextNumber.Text = res.ToString();
        }

        private void DegreeOfTenBtn_Click(object sender, RoutedEventArgs e)
        {
            double res = Math.Pow(10, Convert.ToDouble(TextNumber.Text));
            TextNumber.Text = res.ToString();
        }

        private void LnBtn_Click(object sender, RoutedEventArgs e)
        {
            double res = Math.Log(Convert.ToDouble(TextNumber.Text));
            TextNumber.Text = res.ToString();
        }

        private void ModBtn_Click(object sender, RoutedEventArgs e)
        {
            TextNumber.Text += "%";
        }

        private void InvBtn_Click(object sender, RoutedEventArgs e)
        {
            double res = 1 / Convert.ToDouble(TextNumber.Text);
            TextNumber.Text = res.ToString();
        }

        private double ConvertDegreesAndRadians(double measurement)
        {
            if (degreesOrRadians == "Degrees")
            {
                return measurement;
            }

            return measurement * (Math.PI / 180);
        }

        private void SinBtn_Click(object sender, RoutedEventArgs e)
        {
            double res = Math.Sin(ConvertDegreesAndRadians(Convert.ToDouble(TextNumber.Text)));
            TextNumber.Text = res.ToString();
        }

        private void CosBtn_Click(object sender, RoutedEventArgs e)
        {
            double res = Math.Cos(ConvertDegreesAndRadians(Convert.ToDouble(TextNumber.Text)));
            TextNumber.Text = res.ToString();
        }

        private void TanBtn_Click(object sender, RoutedEventArgs e)
        {
            double res = Math.Tan(ConvertDegreesAndRadians(Convert.ToDouble(TextNumber.Text)));
            TextNumber.Text = res.ToString();
        }

        private void SinhBtn_Click(object sender, RoutedEventArgs e)
        {
            double res = Math.Sinh(ConvertDegreesAndRadians(Convert.ToDouble(TextNumber.Text)));
            TextNumber.Text = res.ToString();
        }

        private void CoshBtn_Click(object sender, RoutedEventArgs e)
        {
            double res = Math.Cosh(ConvertDegreesAndRadians(Convert.ToDouble(TextNumber.Text)));
            TextNumber.Text = res.ToString();
        }

        private void TanhBtn_Click(object sender, RoutedEventArgs e)
        {
            double res = Math.Tanh(ConvertDegreesAndRadians(Convert.ToDouble(TextNumber.Text)));
            TextNumber.Text = res.ToString();
        }

        private void PiBtn_Click(object sender, RoutedEventArgs e)
        {
            double pi = Math.PI;
            TextNumber.Text = pi.ToString();
        }

        private void DegreesBtn_Checked(object sender, RoutedEventArgs e)
        {
            degreesOrRadians = (string)((RadioButton)sender).Content;
        }

        private void RadiansBtn_Checked(object sender, RoutedEventArgs e)
        {
            degreesOrRadians = (string)((RadioButton)sender).Content;
        }

        /*private void Result()
        {
            string strOperation;
            int operation;

            if (TextNumber.Text.Contains('+'))
                operation = TextNumber.Text.IndexOf("+");
            else if (TextNumber.Text.Contains('-'))
                operation = TextNumber.Text.IndexOf("-");
            else if (TextNumber.Text.Contains('*'))
                operation = TextNumber.Text.IndexOf("*");
            else if (TextNumber.Text.Contains('/'))
                operation = TextNumber.Text.IndexOf("/");
            else if (TextNumber.Text.Contains('~'))
                operation = TextNumber.Text.IndexOf("~");
            else if (TextNumber.Text.Contains('^'))
                operation = TextNumber.Text.IndexOf("^");
            else
                operation = TextNumber.Text.IndexOf("%");

            strOperation = TextNumber.Text.Substring(operation, 1);
            double operator1 = Convert.ToDouble(TextNumber.Text[..operation]); //.Substring(0, operation)
            double operator2 = Convert.ToDouble(TextNumber.Text.Substring(operation + 1, TextNumber.Text.Length - operation - 1));

            if (strOperation == "+")
            {
                CE();
                TextNumber.Text = $"{operator1 + operator2}";
            }
            else if (strOperation == "-")
            {
                CE();
                TextNumber.Text = $"{operator1 - operator2}";
            }
            else if (strOperation == "*")
            {
                CE();
                TextNumber.Text = $"{operator1 * operator2}";
            }
            else if (strOperation == "/")
            {
                CE();
                TextNumber.Text = $"{operator1 / operator2}";
            }
            else if (strOperation == "~")
            {
                CE();
                TextNumber.Text = $"{Math.Round(Math.Pow(operator2, 1/(double)operator1), 5)}";
            }
            else if (strOperation == "^")
            {
                CE();
                TextNumber.Text = $"{Math.Pow(operator1, operator2)}";
            }
            else
            {
                CE();
                TextNumber.Text = $"{operator1 % operator2}";
            }
        }*/
    }
}
