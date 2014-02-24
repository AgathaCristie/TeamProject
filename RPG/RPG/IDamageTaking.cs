using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public interface IDamageTaking
    {
        // properties:
        int DamageResist { get; set; } // set separately in constructor for each monster/hero class. Increases for heroes as they gain levels
        int CurrentHealth { get; set; } // the same as ^
    }
}
