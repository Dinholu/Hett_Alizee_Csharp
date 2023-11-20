using Hett_Alizée_Tp1.SpaceInvadersArmory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hett_Alizée_Tp1.Models
{
    internal interface ISpaceship
    {
        string Name { get; set; }
        double Structure { get; set; }
        double Shield { get; set; }
        bool IsDestroyed { get; }
        int MaxWeapons { get; }
        List<Weapon> Weapons { get; }
        double AverageDamages { get; }
        double CurrentStructure { get; set; }
        double CurrentShield { get; set; }
        bool BelongsPlayer { get; }
        void TakeDamages(double damages);
        void RepairShield(double repair);
        void ShootTarget(Spaceship target);
        void ReloadWeapons();
        void AddWeapon(Weapon weapon);
        void RemoveWeapon(Weapon oWeapon);
        void ClearWeapons();
        void ViewShip();
        void ViewWeapons();

    }
}
