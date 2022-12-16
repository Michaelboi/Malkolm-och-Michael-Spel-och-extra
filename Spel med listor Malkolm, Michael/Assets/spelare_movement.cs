using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace spel_move
{
    public class spelare_movement : MonoBehaviour
    {
        // Den här funktionen är till för att kunna använda kroppen av objectet och sätta den som en variabel
        public Rigidbody RB;
        public void kub_movement()
        {
            RB = GetComponent<Rigidbody>();
            
        }

        // inputs för att spelaren ska kunna röra sig
        public void movement()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RB.velocity = new Vector3(0, 5, 0);
            }
            if (Input.GetKeyUp("space"))
            {
                RB.velocity = new Vector3(0, 0, 0);
            }
            if (Input.GetKeyDown("up"))
            {
                RB.velocity = new Vector3(0, 0, 5);
            }
            if (Input.GetKeyUp("up"))
            {
                RB.velocity = new Vector3(0, 0, 0);
            }
            if (Input.GetKeyDown("right"))
            {
                RB.velocity = new Vector3(5, 0, 0);
            }
            if (Input.GetKeyUp("right"))
            {
                RB.velocity = new Vector3(0, 0, 0);
            }
            if (Input.GetKeyDown("down"))
            {
                RB.velocity = new Vector3(0, 0, -5);
            }
            if (Input.GetKeyUp("down"))
            {
                RB.velocity = new Vector3(0, 0, 0);
            }
            if (Input.GetKeyDown("left"))
            {
                RB.velocity = new Vector3(-5, 0, 0);
            }
            if (Input.GetKeyUp("left"))
            {
                RB.velocity = new Vector3(0, 0, 0);
            }
        }
    }
}
