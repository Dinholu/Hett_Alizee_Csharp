using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Hett_Alizée_Tp1.SpaceInvadersArmory;


namespace Hett_Alizée_Tp1.Models
{
    internal class Spaceship : ISpaceship
    {
        protected int MaxStructure { get; set; }
        protected int MaxShield { get; set; }
        public double CurrentStructure { get; set; }
        public double CurrentShield { get; set; }
        public bool IsDestroyed => CurrentStructure <= 0;
        public double MinDamage { get; set; }
        public double MaxDamage { get; set; }
        public double AverageDamages => (MinDamage + MaxDamage) / 2;
        public string Name { get; set; }
        public double Structure { get; set; }
        public double Shield { get; set; }
        public int MaxWeapons { get; private set; }

        public List<Weapon> Weapons { get; }

        public bool BelongsPlayer { get; private set; }

        private Armory _armory;


        public Spaceship(int maxStructure, int maxShield, Armory armory, string name)
        {
            Name = name;
            MaxStructure = maxStructure;
            MaxShield = maxShield;
            CurrentShield = MaxShield;
            CurrentStructure = MaxStructure;
            Weapons = new List<Weapon>();
            _armory = armory;
        }

        public virtual void TakeDamages(double damages)
        {
            if (damages <= 0)
            {
                Console.WriteLine($"Pas de dégâts subis.");
                return;
            }

            if (CurrentShield > 0)
            {
                CurrentShield -= damages;
                if (CurrentShield < 0)
                {
                    CurrentStructure += CurrentShield;
                    CurrentShield = 0;
                }
            }
            else
            {
                CurrentStructure -= damages;
            }

            Console.WriteLine($"Dégats subis : {damages}");
            Console.WriteLine($"Bouclier restant : {CurrentShield}");
            Console.WriteLine($"Structure restante : {CurrentStructure}");

            if (IsDestroyed)
            {
                Console.WriteLine($"{this.Name} détruit ! ");
            }
        }

        public void RepairShield(double repair) {
            if (CurrentShield < MaxShield)
            {
                CurrentShield += repair;
                if (CurrentShield > MaxShield)
                {
                    CurrentShield = MaxShield;
                }
                Console.WriteLine($"{this.Name} - Bouclier restauré : {CurrentShield}");
            }
            else
            {
                Console.WriteLine($"Pas de restauration de bouclier pour {this.Name}");
            }

        }
        public virtual void ShootTarget(Spaceship target)
        {
            if (Weapons != null)
            {
                foreach (var weapon in Weapons)
                {
                    if (!weapon.IsReload)
                    {
                        double damage = weapon.Shoot();
                        target.TakeDamages(damage);
                    }
                    else
                    {
                        Console.WriteLine("Les armes doivent recharger");
                    }
                }
            }
        }
        public void ReloadWeapons() {
            foreach (var weapon in Weapons)
            {
                weapon.ReduceReloadTime();
            }
        }

        public void AddWeapon(Weapon weapon)
        {
            if (!_armory.Weapons.Contains(weapon))
            {
                throw new ArmoryException("Weapon not found in Armory.");
            }

            if (Weapons.Count < 3)
                Weapons.Add(weapon);
            else
                throw new InvalidOperationException("Spaceship is full");
        }

        public void RemoveWeapon(Weapon weapon)
        {
            Weapons.Remove(weapon);
        }

        public void ClearWeapons()
        {
            Weapons.Clear();
        }

        public void ViewWeapons()
        {
            foreach (var weapon in Weapons)
            {
                Console.WriteLine($"{weapon.Type} - Max Damage: {weapon.MaxDamage} - Min Damage: {weapon.MinDamage}");
            }
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
            Console.WriteLine($"Average Damage of ship = {AverageDamages}");
        }

    }


}
