using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public interface IDamageMaking
    {
        // properties:
        public int DamageInflict { get; protected set; } // set separately in constructor for each monster/hero class 
        
        // method:
        public void InflictDamage();
    }
}
