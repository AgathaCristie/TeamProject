namespace RPG.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using RPG.Heroes;

    public class Weapon : BaseItem
    {
        public HandsWeaponWieldEnumeration Hands { get; protected set; }
        public int AttackDamage { get; protected set; }

        public Weapon(string weaponName, string imagePath, HandsWeaponWieldEnumeration handsWield, int attackDamage) :
            base(weaponName, imagePath)
        {
            this.Hands = handsWield;
            this.AttackDamage = attackDamage;
        }

        public override void Equip(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
