using Hett_Alizée_Tp1.SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hett_Alizée_Tp1.Models.SpaceShips
{
    internal class Rocinante : Spaceship
    {
        public Rocinante(Armory armory) : base(3, 5, armory, "Rocinante") 
        {
            var torpedo = armory.Weapons.FirstOrDefault(w => w.Name == "Torpille");
            if (torpedo != null)
            {
                AddWeapon(torpedo);
            }
        }

        public override void TakeDamages(double damages)
        {
            Random random = new Random();
            if (random.Next(2) == 0) 
            {
                base.TakeDamages(damages);
            }
        }
    }
}
