
namespace Hett_Alizée_Tp1.SpaceInvadersArmory
{
    internal class Armory
    {
        public List<Weapon> Weapons { get; set; }

        public Armory()
        {
            Weapons = new List<Weapon>();
            Init();
        }

        private void Init()
        {
            Weapons.Add(new Weapon { Name = "Laser", MinDamage = 2, MaxDamage = 3, Type = EWeaponType.Direct, ReloadTime = 2 });
            Weapons.Add(new Weapon { Name = "Hammer", MinDamage = 1, MaxDamage = 8, Type = EWeaponType.Explosive, ReloadTime = 1.5 });
            Weapons.Add(new Weapon { Name = "Torpille", MinDamage = 3, MaxDamage = 3, Type = EWeaponType.Guided, ReloadTime = 2 });
            Weapons.Add(new Weapon { Name = "Mitrailleuse", MinDamage = 6, MaxDamage = 8, Type = EWeaponType.Direct, ReloadTime = 1 });
            Weapons.Add(new Weapon { Name = "EMG", MinDamage = 1, MaxDamage = 7, Type = EWeaponType.Explosive, ReloadTime = 1.5 });
            Weapons.Add(new Weapon { Name = "Missile", MinDamage = 4, MaxDamage = 100, Type = EWeaponType.Guided, ReloadTime = 2 });
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
