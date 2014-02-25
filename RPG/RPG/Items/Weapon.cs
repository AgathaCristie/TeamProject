namespace RPG.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Weapon
    {
        public enum slot
        {
            OneHand,
            TwoHand,
            OffHand,
            Shield
        }
        public slot Slot { get; protected set; }
        public string Name { get; protected set; }

        public uint Resistance { get; protected set; }

        public string ImagePath { get; protected set; }

        public Weapon(Weapon.slot Slot, string Name, uint Resistance, string ImagePath)
        {
            this.Slot = Slot;
            this.Name = Name;
            this.Resistance = Resistance;
            this.ImagePath = ImagePath;
        }
    }
}
