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
            
            spawnpos.Add(new Vector3(0, defaultY, 1));
            spawnpos.Add(new Vector3(6, defaultY, 6));
            spawnpos.Add(new Vector3(6, defaultY, -3.5f));
            spawnpos.Add(new Vector3(0, defaultY, -8.5f));
            spawnpos.Add(new Vector3(0, defaultY, -7.5f));
            spawnpos.Add(new Vector3(6, defaultY, -23f));
            spawnpos.Add(new Vector3(0, defaultY, -28f));
            spawnpos.Add(new Vector3(6, defaultY, -14f));

            // Sätter objectets position till någon av de som finns inom listan
            gameObject.transform.position = spawnpos[spawn.Next(0, 7)];
        }

    }
}
