using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBattle.Users
{
    class Mage : Enemy
    {
        public Mage(string type, int lvl, double hP, double damage, double mP, int strength, int dexterity, int luck, int intelligence, int constitution, int evasion, int crit) : base(type, lvl, hP, damage, mP, strength, dexterity, luck, intelligence, constitution, evasion, crit)
        {
        }
    }
}
