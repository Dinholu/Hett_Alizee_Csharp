using Hett_Alizée_Tp1.SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hett_Alizée_Tp1.Models.SpaceShips
{
    internal class Tardis : Spaceship, IAbility
    {
        public Tardis(Armory armory) : base(1, 0, armory, "Tardis") { }

        public void UseAbility(List<Spaceship> spaceships)
        {
            Console.WriteLine($"{this.Name} utilise son pouvoir");
            if (spaceships.Count > 1)
            {
                Random random = new Random();
                int shipIndex = random.Next(spaceships.Count);
                Spaceship selectedShip = spaceships[shipIndex];

                if (selectedShip == this)
                {
                    return; 
                }

                spaceships.RemoveAt(shipIndex); 
                int newPosition = random.Next(spaceships.Count);
                spaceships.Insert(newPosition, selectedShip); 
            }
        }

        public override void ShootTarget(Spaceship target)
        {
            Console.WriteLine($"{Name} n'a pas d'arme et ne peux donc pas tirer");
        }

    }
}
