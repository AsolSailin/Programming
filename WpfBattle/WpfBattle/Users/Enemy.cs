using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBattle.Users
{
    public class Enemy
    {
        public string Type { get; set; }
        public int Lvl { get; set; }
        public double HP { get; set; }
        public double Damage { get; set; }
        public double MP { get; set; }
        public double DamageAttack { get; set; } = 3;
        public double MPAttack { get; set; } = 5;
        public double HP_DamageAttack { get; set; } = 5;
        public double HP_MPAttack { get; set; } = 10;
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Luck { get; set; }
        public int Intelligence { get; set; }
        public int Constitution { get; set; }
        public int EvasionPercent { get; set; }
        public int CritDamagePercent { get; set; }
        public bool Shild { get; set; }
        public Enemy(string type, int lvl, double hP, double damage, double mP, int strength, int dexterity, int luck, int intelligence, int constitution, int evasion, int crit)
        {
            Type = type;
            Lvl = lvl;
            HP = hP;
            Damage = damage;
            MP = mP;
            Strength = strength;
            Dexterity = dexterity;
            Luck = luck;
            Intelligence = intelligence;
            Constitution = constitution;
            EvasionPercent = evasion;
            CritDamagePercent = crit;
        }
    }
}
