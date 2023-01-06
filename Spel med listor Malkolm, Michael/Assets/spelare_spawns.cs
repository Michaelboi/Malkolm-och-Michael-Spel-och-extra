using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace spawnpositions
{
    public class spelare_spawns : MonoBehaviour
    {
        
        // Här finns en lista med olika positioner x, y, z
        System.Random spawn = new System.Random();
        List<Vector3> spawnpos = new List<Vector3>();
        int defaultY = 1;
        
        // Funktion för startpositioner
        public void position()
        {
            
            spawnpos.Add(new Vector3(2, defaultY, 0));
            spawnpos.Add(new Vector3(5, defaultY, 0));
            spawnpos.Add(new Vector3(-2, defaultY, 0));
            spawnpos.Add(new Vector3(5, defaultY, 0));

            // Sätter objectets position till någon av de som finns inom listan
            gameObject.transform.position = spawnpos[spawn.Next(0, 3)];
        }

    }
}
