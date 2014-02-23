namespace RPG.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using RPG.Heroes;

    public class Consumable : BaseItem
    {
        public int Quantity { get; protected set; }

        public Consumable(string consumableName, int quantity) :
            base(consumableName)
        {
            this.Quantity = quantity;
        }

        public override void Equip(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
