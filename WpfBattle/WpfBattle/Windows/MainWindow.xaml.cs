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
using WpfBattle.Windows;
using WpfBattle.Users;

namespace WpfBattle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User user = new User();
        private Enemy enemy;
        public int number;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            Battle battle = new Battle(user);
            battle.Show();
        }

        private void LvlBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(LvlText.Text) < user._maxLvl)
            {
                number = int.Parse(LvlText.Text);
                number += 1;
                user.Lvl = number;
                LvlText.Text = user.Lvl.ToString();
                number = int.Parse(PointText.Text);
                number -= 1;
                PointText.Text = number.ToString();
                PointText.Text = user.PointsCount().ToString();
            }
        }

        private void StrBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(PointText.Text) > 0 && int.Parse(StrText.Text) < user._max)
            {
                number = int.Parse(StrText.Text);
                number += 1;
                user.Strength = number;
                StrText.Text = user.Strength.ToString();
                number = int.Parse(PointText.Text);
                number -= 1;
                PointText.Text = number.ToString();
                DamageText.Text = user.Damage.ToString();
            }
        }

        private void DexBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(PointText.Text) > 0 && int.Parse(DexText.Text) < user._max)
            {
                number = int.Parse(DexText.Text);
                number += 1;
                user.Dexterity = number;
                DexText.Text = user.Dexterity.ToString();
                number = int.Parse(PointText.Text);
                number -= 1;
                PointText.Text = number.ToString();
            }
        }

        private void LuckBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(PointText.Text) > 0 && int.Parse(LuckText.Text) < user._max)
            {
                number = int.Parse(LuckText.Text);
                number += 1;
                user.Luck = number;
                LuckText.Text = user.Luck.ToString();
                number = int.Parse(PointText.Text);
                number -= 1;
                PointText.Text = number.ToString();
            }
        }

        private void IntBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(PointText.Text) > 0 && int.Parse(IntText.Text) < user._max)
            {
                number = int.Parse(IntText.Text);
                number += 1;
                user.Intelligence = number;
                IntText.Text = user.Intelligence.ToString();
                number = int.Parse(PointText.Text);
                number -= 1;
                PointText.Text = number.ToString();
                DamageText.Text = user.Damage.ToString();
                MPText.Text = user.MP.ToString();
            }
        }

        private void ConBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(PointText.Text) > 0 && int.Parse(ConText.Text) < user._max)
            {
                number = int.Parse(ConText.Text);
                number += 1;
                user.Constitution = number;
                ConText.Text = user.Constitution.ToString();
                number = int.Parse(PointText.Text);
                number -= 1;
                PointText.Text = number.ToString();
                HPText.Text = user.HP.ToString();
            }
        }


    }
}
