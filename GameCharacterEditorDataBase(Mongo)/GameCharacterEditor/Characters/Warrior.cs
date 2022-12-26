﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class Warrior : Character
    {
        public override int Strength
        {
            get { return _strength; }
            set
            {
                if (value < minStrength || value > maxStrength)
                    throw new Exception();

                HP += (value - _strength) * 2;
                Attack += (value - _strength) * 5;
                _strength = value;
            }
        }
        public override int Dexterity
        {
            get { return _dexterity; }
            set
            {
                if (value < minDexterity || value > maxDexterity)
                    throw new Exception();

                Attack += (value - _dexterity) * 1;
                PDef += (value - _dexterity) * 1;
                _dexterity = value;
            }
        }
        public override int Constitution
        {
            get { return _constitution; }
            set
            {
                if (value < minConstitution || value > maxConstitution)
                    throw new Exception();

                HP += (value - _constitution) * 10;
                PDef += (value - _constitution) * 12;
                _constitution = value;
            }
        }
        public override int Intelligence
        {
            get { return _intelligence; }
            set
            {
                if (value < minIntelligence || value > maxIntelligence)
                    throw new Exception();

                MP += (value - _intelligence) * 1;
                MPAttack += (value - _intelligence) * 1;
                _intelligence = value;
            }
        }
        public Warrior()
        {
            Type = "WARRIOR";
            Points = 25;
            minStrength = 30;
            maxStrength = 250;
            minDexterity = 15;
            maxDexterity = 70;
            minConstitution = 20;
            maxConstitution = 100;
            minIntelligence = 10;
            maxIntelligence = 50;
            Strength = minStrength;
            Dexterity = minDexterity;
            Constitution = minConstitution;
            Intelligence = minIntelligence;
        }
    }
}
