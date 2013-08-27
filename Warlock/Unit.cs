using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

    public class Unit:MonoBehaviour

    {
        
        float curHealth;
        float maxHealth = 100;
        float regHealth = 0;

        float curArmor;
        float maxArmor = 100;
        float regArmor = 0;

        float curShield;
        float maxShield = 100;
        float regShield = 0;

        

        public Unit()
        {
            curArmor = maxArmor;
            curShield = maxShield;
            curHealth = maxHealth;
        }

        public void GetDamage(float damage, ENUM.DAMAGETYPE damageType)
        {
            switch (damageType)
            {
                case ENUM.DAMAGETYPE.Normal: 
                    break;
                case ENUM.DAMAGETYPE.Poisen:
                    break;
                case ENUM.DAMAGETYPE.Fire:
                    break;
                case ENUM.DAMAGETYPE.Electro:
                    break;
                case ENUM.DAMAGETYPE.Ice:
                    break;
            }
        }

        void Update()
        {
            curHealth = Regenerate(curHealth, maxHealth, regHealth);
            curArmor = Regenerate(curArmor, maxArmor, regArmor);
            curShield = Regenerate(curShield, maxShield, regShield);
        }

        private float Regenerate(float curValue, float maxValue, float regValue)
        {
            if (curValue < maxValue && regValue > 0)
            {return Mathf.Clamp(curValue + regValue * Time.deltaTime, 0, maxValue);}
            else
            { return curValue; }

        }
        
    }
