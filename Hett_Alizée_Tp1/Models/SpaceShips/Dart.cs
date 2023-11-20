using Hett_Alizée_Tp1.SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hett_Alizée_Tp1.Models.SpaceShips
{
    internal class Dart : Spaceship
    {
        public Dart(Armory armory) : base(10, 3, armory, "Dart")
        {
            var laser = armory.Weapons.FirstOrDefault(w => w.Name == "Laser");
            if (laser != null)
            {
                AddWeapon(laser);
            }
        }

        public override void ShootTarget(Spaceship target)
        {
            foreach (var weapon in Weapons)
            {
                if (weapon.Type == EWeaponType.Direct)
                {
                    double damage = weapon.Shoot();
                    target.TakeDamages(damage);
                }
                else if (!weapon.IsReload)
                {
                    double damage = weapon.Shoot();
                    target.TakeDamages(damage);
                }
            }
        }
    }

}
