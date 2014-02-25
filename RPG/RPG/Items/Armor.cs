namespace RPG.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Armor
    {
        public enum slot
        {
            Head,
            Body,
            Hands,
            Feet
        }
        public slot Slot { get; protected set; }
        public string Name { get; protected set; }

        public uint Resistance { get; protected set; }

        public string ImagePath { get; protected set; }

        public Armor(Armor.slot Slot, string Name, uint Resistance, string ImagePath)
        {
            this.Slot = Slot;
            this.Name = Name;
            this.Resistance = Resistance;
            this.ImagePath = ImagePath;
        }
    }
}
