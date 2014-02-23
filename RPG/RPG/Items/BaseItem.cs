namespace RPG.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using RPG.Heroes;
    public abstract class BaseItem : IEquipable
    {
        public string Name { get; protected set; }
        public bool Equipped { get; protected set; }

        public BaseItem(string name)
        {
            this.Name = name;
            this.Equipped = false;
        }

        public abstract void Equip(Player player);
    }
}
