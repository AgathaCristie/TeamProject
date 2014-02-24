using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public interface IDamageTaking
    {
        protected int currentHealth;
        
        // properties:
        public int DamageResist { get; protected set; } // set separately in constructor for each monster/hero class. Increases for heroes as they gain levels
        public int CurrentHealth { get; set; } // the same as ^
    }
}
