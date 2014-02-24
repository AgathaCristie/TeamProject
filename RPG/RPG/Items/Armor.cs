﻿namespace RPG.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using RPG.Heroes;

    public class Armor : BaseItem
    {
        public ArmorPartEnumeration ArmorPlacement { get; protected set; }
        public int DefenceValue { get; protected set; }

        public Armor(string armorName, string imagePath, ArmorPartEnumeration armorPlacement, int defence) :
            base(armorName, imagePath)
        {
            this.ArmorPlacement = armorPlacement;
            this.DefenceValue = defence;
        }

        public override void Equip(Player player)
        {
            
        }
    }
}
