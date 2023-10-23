using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hett_Alizée_Tp1
{
    public enum EWeaponType
    {
        Direct,
        Explosive,
        Guided
    }

    internal class Weapon
    {
        public int MinDamage { get; set; }        
        public int MaxDamage { get; set; }
        public EWeaponType Type { get; set; }
    }
}
