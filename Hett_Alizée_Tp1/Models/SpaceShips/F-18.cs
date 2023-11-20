using Hett_Alizée_Tp1.SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hett_Alizée_Tp1.Models.SpaceShips
{
    internal class F_18 : Spaceship, IAbility
    {

        public F_18(Armory armory) : base(15, 0, armory, "F18") { }

        public void UseAbility(List<Spaceship> spaceships)
        {
            int position = spaceships.IndexOf(this);
            Console.WriteLine($"{this.Name} utilise son pouvoir");
            bool isPlayerNext = position + 1 < spaceships.Count && spaceships[position + 1] is ViperMKII;
            bool isPlayerPrevious = position - 1 >= 0 && spaceships[position - 1] is ViperMKII;

            if (isPlayerNext || isPlayerPrevious)
            {
                ViperMKII playerSpaceship = (isPlayerNext ? spaceships[position + 1] : spaceships[position - 1]) as ViperMKII;
                Console.WriteLine($"{this.Name} a trouvé un joueur et lui a fait perdre 10 points");
                playerSpaceship.TakeDamages(10);

                this.CurrentStructure = 0;
            }
        }

        public override void ShootTarget(Spaceship target)
        {
            Console.WriteLine($"{Name} n'a pas d'arme et ne peux donc pas tirer");
        }
    }
}
