using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace City_Saver.ObjectClasses
{
    class People
    {
        
        private int health;//the HP of the object 
        private int abilityPower;//the MP of the object
        private bool hasWeapon;
      //private int weaponType;
        //the attribute for the object's HP
        //inherited class can assign various HP values
        protected int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        protected int Magic
        {
            get
            {
                return abilityPower;
            }
            set
            {
                abilityPower = value;
            }
        }

        //protected bool weapon
        //{
        //    get
        //    {
        //        return hasWeapon;
        //    }
        //    set
        //    {
        //        hasWeapon = value;
        //    }
        //}

        //protected int weaponType
        //{
        //    get
        //    {
        //        return weaponType;
        //    }
        //    set
        //    {
        //        weaponType = value;
        //    }
        //}

    }
}
