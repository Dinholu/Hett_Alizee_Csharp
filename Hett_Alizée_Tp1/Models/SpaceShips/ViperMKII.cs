using Hett_Alizée_Tp1.SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hett_Alizée_Tp1.Models.SpaceShips
{
    internal class ViperMKII : Spaceship
    {
        public ViperMKII(Armory armory) : base(10, 15, armory, "ViperMKIII") // 10 structure, 15 bouclier
        {
            AddWeapon(armory.Weapons.FirstOrDefault(w => w.Name == "Mitrailleuse"));
            AddWeapon(armory.Weapons.FirstOrDefault(w => w.Name == "EMG"));
            AddWeapon(armory.Weapons.FirstOrDefault(w => w.Name == "Missile"));
        }

        public override void ShootTarget(Spaceship target)
        {
            var reloadedWeapons = Weapons.Where(w => !w.IsReload).ToList();
            if (reloadedWeapons.Any())
            {
                Random random = new Random();
                var weaponToUse = reloadedWeapons[random.Next(reloadedWeapons.Count)];

                double damage = weaponToUse.Shoot();
                target.TakeDamages(damage);
            }
        }
    }
}
