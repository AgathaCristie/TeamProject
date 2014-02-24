using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RPG.Heroes;
namespace RPG.Items
{
    public class Sword : Weapon
    {
        public Sword(string swordName, string imagePath, HandsWeaponWieldEnumeration handsWield, int attackDamage) :
            base(swordName, imagePath, handsWield, attackDamage)
        {
        }

        public override void Equip(Player player)
        {
            if (player is Hero)
            {
                
            }
        }
    }
}
