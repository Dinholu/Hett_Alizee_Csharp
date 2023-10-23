using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hett_Alizée_Tp1
{
    internal class SpaceInvaders
    {
        private List<Player> _players;
        private Armory _armory;

        public SpaceInvaders()
        {
            _players = new List<Player>();
            _armory = new Armory();
            Init();
        }

        private void Init()
        {
            _players.Add(new Player("john", "doe", "JD"));
            _players.Add(new Player("jane", "smith", "JS"));
            _players.Add(new Player("alice", "johnson", "AJ"));

            foreach (var player in _players)
            {
                var ship = new Spaceship(100, 50, _armory);
                player.DefaultSpaceship = ship;
                try { 
                ship.AddWeapon(_armory.Weapons[0]);
                ship.AddWeapon(_armory.Weapons[1]);
                ship.AddWeapon(new Weapon{ MinDamage = 20, MaxDamage = 40, Type = EWeaponType.Direct });
                }
                catch (ArmoryException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

        }

        public static void Main()
        {
            var game = new SpaceInvaders();
            Console.WriteLine("=== Armory ===");
            game._armory.ViewArmory();

            Console.WriteLine("\n=== Players and their Spaceships ===");
            foreach (var player in game._players)
            {
                
                Console.WriteLine(player.ToString());
                Console.WriteLine($"The player has a homonym : {player.Equals(game)}");
                player.DefaultSpaceship?.ViewShip();
            }
        }
    }
}
