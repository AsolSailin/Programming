using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBattle.Users
{
    public class User
    {
        public int Points { get; set; } = 15;
        public int Lvl { get; set; }
        public int _max { get; set; } = 50;
        public int _maxLvl { get; set; } = 10;
        public int _strength;
        public int _dexterity;
        public int _constitution;
        public int _intelligence;
        public int _luck;
        public int Strength
        {
            get { return _strength; }
            set
            {
                if (value > _max)
                    throw new Exception();

                Damage += (value - _strength) * 1;
                _strength = value;
            }
        }
        public int Dexterity
        {
            get { return _dexterity; }
            set
            {
                if (value > _max)
                    throw new Exception();

                EvasionPercent += (value - _dexterity) * 1; //1%
                _dexterity = value;
            }
        }
        public int Luck 
        { 
            get { return _luck; }
            set
            {
                if (value > _max)
                    throw new Exception();

                CritDamagePercent += (value - _luck) * 1; //1%
                _luck = value;
            }
        }
        public int Intelligence
        {
            get { return _intelligence; }
            set
            {
                if (value > _max)
                    throw new Exception();

                Damage += (value - _intelligence) * 1;
                MP += (value - _intelligence) * 7;
                _intelligence = value;
            }
        }
        public int Constitution
        {
            get { return _constitution; }
            set
            {
                if (value > _max)
                    throw new Exception();

                HP += (value - _constitution) * 5;
                _constitution = value;
            }
        }
        public double HP { get; set; } = 50;
        public double MP { get; set; }
        public double Damage { get; set; }
        public double MPAttack { get; set; } = 5;
        public double DamageAttack { get; set; } = 3;
        public double HP_MPAttack { get; set; } = 10;
        public double HP_DamageAttack { get; set; } = 5;

        public int EvasionPercent { get; set; }
        public int CritDamagePercent { get; set; }
        public bool Shild { get; set; }

        public int PointsCount()
        {
            switch(Lvl)
            {
                case 1:
                    Points += 2;
                    break;
                case 2:
                    Points += 3;
                    break;
                case 3:
                    Points += 2;
                    break;
                case 4:
                    Points += 3;
                    break;
                case 5:
                    Points += 5;
                    break;
                case 6:
                    Points += 5;
                    break;
                case 7:
                    Points += 5;
                    break;
                case 8:
                    Points += 10;
                    break;
                case 9:
                    Points += 5;
                    break;
                case 10:
                    Points += 15;
                    break;
            }
            return Points;
        }
    }
}
