using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hett_Alizée_Tp1
{
    internal class Spaceship
    {
        public int MaxStructure { get; set; }
        public int MaxShield { get; set; }
        public int CurrentShield { get; set; }
        public int CurrentStructure { get; set; }
        public bool IsDestroyed => CurrentStructure <= 0;

        private Armory _armory;

        private List<Weapon> _weapons;

        public Spaceship(int maxStructure, int maxShield, Armory armory)
        {
            MaxStructure = maxStructure;
            MaxShield = maxShield;
            CurrentStructure = maxStructure;
            CurrentShield = maxShield;
            _weapons = new List<Weapon>();
            _armory = armory;
        }
        public void AddWeapon(Weapon weapon)
        {
            if (!_armory.Weapons.Contains(weapon))
            {
                throw new ArmoryException("Weapon not found in Armory.");
            }

            if (_weapons.Count < 3)
                _weapons.Add(weapon);
            else
                throw new InvalidOperationException("Spaceship is full");
        }

        public void RemoveWeapon(Weapon weapon)
        {
            _weapons.Remove(weapon);
        }

        public void ClearWeapons()
        {
            _weapons.Clear();
        }

        public void ViewWeapons()
        {
            foreach (var weapon in _weapons)
            {
                Console.WriteLine($"{ weapon.Type} - Max Damage: {weapon.MaxDamage} - Min Damage: {weapon.MinDamage}");
            }
        }

        public double AverageDamages()
        {
            double totalDamage = 0;
            foreach (var weapon in _weapons)
            {
                totalDamage += (weapon.MinDamage + weapon.MaxDamage) / 2.0;
            }
            return _weapons.Count == 0 ? 0 : totalDamage / _weapons.Count;
        }

        public void ViewShip()
        {
            Console.WriteLine($"Spaceship Stats:");
            Console.WriteLine($"Max Structure: {MaxStructure}");
            Console.WriteLine($"Current Structure: {CurrentStructure}");
            Console.WriteLine($"Max Shield: {MaxShield}");
            Console.WriteLine($"Current Shield: {CurrentShield}");
            Console.WriteLine("Weapons:");
            ViewWeapons();
            Console.WriteLine($"Average Damage of ship = {AverageDamages()}");
        }

    }


}
