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
using System.Windows.Shapes;
using WpfBattle.Windows;
using WpfBattle.Users;
using System.Security.Cryptography.X509Certificates;

namespace WpfBattle.Windows
{
    /// <summary>
    /// Логика взаимодействия для Battle.xaml
    /// </summary>
    public partial class Battle : Window
    {
        public User user;
        public Enemy enemy;
        Random rnd = new Random();
        //private bool userHitChance;
        public Battle(User currentUser)
        {
            InitializeComponent();
            user = currentUser;
            int enemyType = rnd.Next(0, 3);
            switch (enemyType)
            {
                case 0:
                    enemy = new Mage("Mage", 7, 20, 11, 56, 3, 4, 5, 8, 5, 4, 5);
                    Role.Text = enemy.Type;
                    break;
                case 1:
                    enemy = new Warrior("Warrior", 7, 20, 14, 7, 13, 3, 3, 1, 5, 3, 3);
                    Role.Text = enemy.Type;
                    break;
                case 2:
                    enemy = new Rogue("Rogue", 7, 20, 14, 14, 12, 5, 1, 2, 5, 5, 1);
                    Role.Text = enemy.Type;
                    break;
            }
            YourHP.Text = user.HP.ToString();
            YourDamage.Text = user.Damage.ToString();
            YourMP.Text = user.MP.ToString();
            EnemyHP.Text = enemy.HP.ToString();
        }
        private void HitBtn_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random(); 
            int userChance = rnd.Next(0,2); //шанс удара юзера
            int enemyChance = rnd.Next(0,2); // шанс удара противника
            int enemyDamage = rnd.Next(0,2); // тип удара противника
            int enemyPercent = rnd.Next(0,100); // процент улонения и крит удара противника
            int userPercent = rnd.Next(0,100); // процент улонения и крит удара юзера
            int userShild = rnd.Next(0,2); //шанс защиты
            int enemyShild = rnd.Next(0, 2);

            /*switch (userChance)
            {
                case 0:
                    userHitChance = true;
                    break;
                case 1:
                    userHitChance = false;
                    break;
            }*/
            
                switch (DamageText.SelectedIndex)
                {
                    case 0: //damage
                    /*if (userHitChance)
                    {*/
                    if (user.Damage > 0 && user.MP > 0)
                    {
                        if (enemyPercent > enemy.EvasionPercent) //не уклонился
                        {
                            if (userPercent > user.CritDamagePercent) //без крит атаки
                            {
                                EnemyHP.Text = (int.Parse(EnemyHP.Text) - enemy.HP_DamageAttack).ToString();
                                enemy.HP = int.Parse(EnemyHP.Text);
                                user.Damage -= user.DamageAttack;
                                YourDamage.Text = user.Damage.ToString();
                                BattleText.Text = $"You hit the enemy";
                            }
                            else
                            {
                                EnemyHP.Text = (int.Parse(EnemyHP.Text) - enemy.HP_DamageAttack * 2).ToString();
                                enemy.HP = int.Parse(EnemyHP.Text);
                                user.Damage -= user.DamageAttack;
                                YourDamage.Text = user.Damage.ToString();
                                BattleText.Text = $"You hit the enemy with a critical hit";
                            }
                        }
                        else
                        {
                            BattleText.Text = $"You missed, the enemy dodged";
                        }
                    }
                    else
                    {
                        BattleText.Text = "You ran out of strength";
                        if (user.Damage < 0)
                        {
                            YourDamage.Text = "0";
                        }
                        else
                        {
                            YourMP.Text = "0";
                        }
                    }
                    break;
                    case 1: //MP damage
                        /*if (userHitChance)
                        {*/
                        switch (enemyShild)
                        {
                            case 0:
                                enemy.Shild = true;
                                break;
                            case 1:
                                enemy.Shild = false;
                                break;
                        }
                    if (user.Damage > 0 && user.MP > 0)
                    {
                        if (enemyPercent > enemy.EvasionPercent && enemy.Shild)
                        {
                            enemy.HP -= enemy.HP_MPAttack * 0.5; //50%
                            EnemyHP.Text = enemy.HP.ToString();
                            user.MP -= user.MPAttack;
                            YourMP.Text = user.MP.ToString();
                            BattleText.Text = $"You hit the enemy with a magic attack 50%";
                        }
                        else if (enemyPercent > enemy.EvasionPercent && !enemy.Shild)
                        {
                            enemy.HP -= enemy.HP_MPAttack;
                            EnemyHP.Text = enemy.HP.ToString();
                            user.MP -= user.MPAttack;
                            YourMP.Text = user.MP.ToString();
                            BattleText.Text = $"You hit the enemy with a magic attack 100%";
                        }
                        else
                        {
                            enemy.HP -= enemy.HP_MPAttack * 0.2;
                            EnemyHP.Text = enemy.HP.ToString();
                            user.MP -= user.MPAttack;
                            YourMP.Text = user.MP.ToString();
                            BattleText.Text = $"You hit the enemy with a magic attack 20%";
                        }
                    }
                    else
                    {
                        BattleText.Text = "You ran out of strength";
                        if (user.Damage < 0)
                        {
                            YourDamage.Text = "0";
                        }
                        else
                        {
                            YourMP.Text = "0";
                        }
                    }
                    break;
                    }
                
            
            
                switch (enemyChance)
                {
                    case 0: // Hit
                    if (enemy.Damage > 0 && enemy.MP > 0)
                    {
                        if (enemyDamage == 0) // Damage
                        {
                            if (userPercent > user.EvasionPercent) //не уклонился
                            {
                                if (enemyPercent > enemy.CritDamagePercent) //без крит атаки
                                {
                                    YourHP.Text = (int.Parse(YourHP.Text) - user.HP_DamageAttack).ToString();
                                    enemy.Damage -= enemy.DamageAttack;
                                    user.HP -= enemy.HP_DamageAttack;
                                    EnemyText.Text = $"The enemy hit you";
                                }
                                else
                                {
                                    YourHP.Text = (int.Parse(YourHP.Text) - user.HP_DamageAttack * 2).ToString();
                                    enemy.Damage -= enemy.DamageAttack;
                                    user.HP -= enemy.HP_DamageAttack;
                                    EnemyText.Text = $"The enemy hit youy with a critical hit";
                                }
                            }
                            else
                            {
                                EnemyText.Text = $"Enemy missed, the you dodged";
                            }
                        }
                        else if (enemyDamage == 1) // MP damage
                        {
                            switch (userShild)
                            {
                                case 0:
                                    user.Shild = true;
                                    break;
                                case 1:
                                    user.Shild = false;
                                    break;
                            }

                            if (userPercent > user.EvasionPercent && user.Shild) //не уклонился и защищен
                            {
                                user.HP -= user.HP_MPAttack * 0.5; //50%
                                enemy.MP -= enemy.MPAttack;
                                YourHP.Text = user.HP.ToString();
                                EnemyText.Text = $"The enemy hit you with a magic attack 50%";
                            }
                            else if (userPercent > user.EvasionPercent && !user.Shild) // не уклонился и не защищен
                            {
                                user.HP -= user.HP_MPAttack;
                                enemy.MP -= enemy.MPAttack;
                                YourHP.Text = user.HP.ToString();
                                EnemyText.Text = $"The enemy hit you with a magic attack 100%";
                            }
                            else
                            {
                                user.HP -= user.HP_MPAttack * 0.2; //20%
                                enemy.MP -= enemy.MPAttack;
                                YourHP.Text = user.HP.ToString();
                                EnemyText.Text = $"The enemy hit you with a magic attack 20%";
                            }
                        }
                    }
                    else
                    {
                        EnemyText.Text = "The enemy ran out of strength";
                    }
                    break;
                    case 1: //Missed
                        if (enemy.Damage > 0 && enemy.MP > 0)
                        {
                            EnemyText.Text = $"The enemy missed";
                        }
                        else
                        {
                            EnemyText.Text = "The enemy ran out of strength";
                        }
                        break;
                }


            if (user.HP <= 0 || enemy.HP <= 0)
            {
                if (user.HP <= 0)
                {
                    YourHP.Text = "0";
                    BattleText.Text = "";
                    EnemyText.Text = "";
                    EndText.Text = $"The enemy has won";
                }
                else if (enemy.HP < 0)
                {
                    EnemyHP.Text = "0";
                    BattleText.Text = "";
                    EnemyText.Text = "";
                    EndText.Text = $"You have won";
                    int enemyType = rnd.Next(0, 3);
                    switch (enemyType)
                    {
                        case 0:
                            enemy = new Mage("Mage", 7, 20, 11, 56, 3, 4, 5, 8, 5, 4, 5);
                            Role.Text = enemy.Type;
                            EnemyHP.Text = enemy.HP.ToString();
                            break;
                        case 1:
                            enemy = new Warrior("Warrior", 7, 20, 14, 7, 13, 3, 3, 1, 5, 3, 3);
                            Role.Text = enemy.Type;
                            EnemyHP.Text = enemy.HP.ToString();
                            break;
                        case 2:
                            enemy = new Rogue("Rogue", 7, 20, 14, 14, 12, 5, 1, 2, 5, 5, 1);
                            Role.Text = enemy.Type;
                            EnemyHP.Text = enemy.HP.ToString();
                            break;
                    }
                }
            }
        }
    }
}
