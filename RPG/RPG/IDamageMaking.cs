using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public interface IDamageMaking
    {
        // properties:
        int DamageInflict { get; set; } // set separately in constructor for each monster/hero class 
        
        // method:
        // void InflictDamage();
    }
}
