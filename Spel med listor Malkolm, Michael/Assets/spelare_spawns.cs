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
        System.Random X = new System.Random();
        List<Vector3> spawnpos = new List<Vector3>();
        int defaultY = 1;
        public void position()
        {
            spawnpos.Add(new Vector3(2, defaultY, 0));
            spawnpos.Add(new Vector3(5, defaultY, 0));
            spawnpos.Add(new Vector3(-2, defaultY, 0));
            spawnpos.Add(new Vector3(5, defaultY, 0));

            gameObject.transform.position = spawnpos[X.Next(0, 2)];
        }

    }
}
