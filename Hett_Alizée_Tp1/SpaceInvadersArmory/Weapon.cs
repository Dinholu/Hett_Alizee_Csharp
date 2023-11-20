using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hett_Alizée_Tp1.SpaceInvadersArmory
{

    internal class Weapon : IWeapon
    {
        public string Name { get; set; }
        public EWeaponType Type { get; set; }
        public double MinDamage { get; set; }
        public double MaxDamage { get; set; }
        public double AverageDamage => (MinDamage + MaxDamage) / 2;
        public double ReloadTime { get; set; }
        public double TimeBeforReload { get; set; }
        public bool IsReload => TimeBeforReload > 0;


        public Weapon()
        {
            TimeBeforReload = ReloadTime;
        }
        public double Shoot()
        {
            if (IsReload)
            {
                return 0;
            }

            TimeBeforReload = ReloadTime;

            Random random = new Random();
            double damage = MinDamage;

            switch (Type)
            {
                case EWeaponType.Direct:
                    if (random.Next(10) == 0) damage = 0;
                    break;
                case EWeaponType.Explosive:
                    damage *= 2;
                    TimeBeforReload *= 2;
                    if (random.Next(4) == 0) damage = 0;
                    break;
                case EWeaponType.Guided:
                    damage = MinDamage;
                    break;
            }

            return damage;
        }

        public void ReduceReloadTime()
        {
            if (TimeBeforReload > 0)
            {
                TimeBeforReload -= 1; 
            }
        }


        public override string ToString()
        {
            return $"{Name} : {Type} ({MinDamage}-{MaxDamage}), ReloadTime: {ReloadTime}";
        }


    }
}
