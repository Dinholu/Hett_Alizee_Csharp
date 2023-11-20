using Hett_Alizée_Tp1.SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hett_Alizée_Tp1.Models.SpaceShips
{
    internal class BWings : Spaceship
    {
        public BWings(Armory armory) : base(30, 0, armory, "BWings") 
        {
            var hammer = armory.Weapons.FirstOrDefault(w => w.Name == "Hammer");
            if (hammer != null)
            {
                AddWeapon(hammer);
            }
        }

        public override void ShootTarget(Spaceship target)
        {
            foreach (var weapon in Weapons)
            {
                if (weapon.Type == EWeaponType.Explosive)
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
