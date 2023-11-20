using System;
using System.Collections.Generic;
using System.Linq;
using Hett_Alizée_Tp1.Models.SpaceShips;
using Hett_Alizée_Tp1.Models;
using Hett_Alizée_Tp1.SpaceInvadersArmory;

namespace Hett_Alizée_Tp1
{
    internal class SpaceInvaders
    {
        private Player _player;
        private List<Spaceship> _enemies;
        private Armory _armory;
        private Random _random;
        private List<Spaceship> _allPlayers;

        public SpaceInvaders()
        {
            _armory = new Armory();
            var viperMKII = new ViperMKII(_armory);
            _player = new Player("john", "doe", "JD", viperMKII);
            _enemies = new List<Spaceship>();
            
            _random = new Random();
            Init();
        }

        private void Init()
        {

            _enemies.Add(new Dart(_armory));
            _enemies.Add(new BWings(_armory));
            _enemies.Add(new Rocinante(_armory));
            _enemies.Add(new F_18(_armory));
            _enemies.Add(new Tardis(_armory));
            _allPlayers = _enemies.Concat(new List<Spaceship> { _player.DefaultSpaceship }).ToList();
        }

        public void PlayRound()
        {
            Console.WriteLine($"\n=== Début du Tour ===");

            foreach (var enemy in _enemies)
            {
                enemy.RepairShield(2);
            }

            foreach (var spaceShip in _allPlayers.ToList())
            {
                if (_enemies.Contains(spaceShip))
                {
                    if (_enemies.Contains(spaceShip) && !spaceShip.IsDestroyed)
                    {
                        Console.WriteLine($"{spaceShip.Name} attaque {_player.Name}");
                        spaceShip.ShootTarget(_player.DefaultSpaceship);
                    }
                }
                
                else
                {
                    var aliveEnemies = _enemies.Where(e => !e.IsDestroyed).ToList();
                    if (aliveEnemies.Any())
                    {
                        var targetEnemy = aliveEnemies[_random.Next(aliveEnemies.Count)];
                        int index = _random.Next(aliveEnemies.Count);
                        Console.WriteLine($"{_player.Name} attaque {_enemies[index].Name}");
                        _player.DefaultSpaceship.ShootTarget(targetEnemy);
                    }

                }   
            }
            //foreach (var enemy in _enemies.OfType<IAbility>().ToList())
            //{
            //    enemy.UseAbility(_allPlayers);
            //}

            foreach (var player in _allPlayers)
            {
                player.ReloadWeapons();
            }

            Console.WriteLine("=== Fin du Tour ===\n");
        }

        public static void Main()
        {
            var game = new SpaceInvaders();

            Console.WriteLine("=======================================================================");
            Console.WriteLine("   Bienvenue dans l'aventure spatiale épique de Space Invaders !");
            Console.WriteLine("   Préparez-vous à embarquer dans une odyssée interstellaire,");
            Console.WriteLine("   où stratégie, courage et esprit d'aventure seront vos meilleurs atouts.");
            Console.WriteLine("   Êtes-vous prêt à prendre les commandes de votre vaisseau ?");
            Console.WriteLine("   Que l'odyssée commence !");
            Console.WriteLine("=======================================================================");
            Console.WriteLine();
            Console.WriteLine();


            while (!game._player.DefaultSpaceship.IsDestroyed || (game._enemies.Any(e => !e.IsDestroyed)))
            {
                game.PlayRound();
            }
            Console.WriteLine("Game Over");
        }
    }
}
