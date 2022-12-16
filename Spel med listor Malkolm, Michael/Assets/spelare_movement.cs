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
            
            if (Input.GetKey(KeyCode.Space))
            {
                RB.AddForce(0, 5, 0);
            }
            if (Input.GetKeyUp("space"))
            {
                RB.AddForce(0, 0, 0);
            }
            if (Input.GetKey("up"))
            {
                RB.AddForce(0, 0, 5);
            }
            if (Input.GetKeyUp("up"))
            {
                RB.AddForce(0, 0, 0);
            }
            if (Input.GetKey("right"))
            {
                RB.AddForce(5, 0, 0);
            }
            if (Input.GetKeyUp("right"))
            {
                RB.AddForce(0, 0, 0);
            }
            if (Input.GetKey("down"))
            {
                RB.AddForce(0, 0, -5);
            }
            if (Input.GetKeyUp("down"))
            {
                RB.AddForce(0, 0, 0);
            }
            if (Input.GetKey("left"))
            {
                RB.AddForce(-5, 0, 0);
            }
            if (Input.GetKeyUp("left"))
            {
                RB.AddForce(0, 0, 0);
            }
        }
    }
}
