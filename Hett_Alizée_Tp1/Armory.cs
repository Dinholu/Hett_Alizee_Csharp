using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hett_Alizée_Tp1
{
    internal class Armory
    {
        public List<Weapon> Weapons { get; private set; }

        public Armory()
        {
            Weapons = new List<Weapon>();
            Init();
        }

        private void Init()
        {
            Weapons.Add(new Weapon { MinDamage = 10, MaxDamage = 20, Type = EWeaponType.Direct });
            Weapons.Add(new Weapon { MinDamage = 40, MaxDamage = 60, Type = EWeaponType.Explosive });
            Weapons.Add(new Weapon { MinDamage = 30, MaxDamage = 50, Type = EWeaponType.Guided });
        }

        public void ViewArmory()
        {
            foreach (var weapon in Weapons)
            {
                Console.WriteLine($"Damage: {weapon.MinDamage}-{weapon.MaxDamage}, Type: {weapon.Type}");
            }
        }
    }
}
