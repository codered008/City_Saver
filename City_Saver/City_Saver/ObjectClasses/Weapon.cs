using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace City_Saver.ObjectClasses
{
    public abstract class Weapon
    {
        private int AtkDmg; //the damage amount for the weapon
        private int reach;//weapon's range

        //creates the attributes for the weapon's variables 
        protected int AttackDamage
        {
            get
            {
                return AtkDmg;
            }

            set
            {
                AtkDmg = value;
            }
        }

        protected int weapon_reach
        {
            get
            {
                return reach;
            }

            set
            {
                reach = value;
            }
        }

    }
}
