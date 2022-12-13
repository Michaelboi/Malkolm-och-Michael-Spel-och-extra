
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
            if (Input.GetKeyDown("space"))
            {
                RB.velocity = new Vector3(0, 5f, 0);
            }
            if (Input.GetKeyUp("space"))
            {
                RB.velocity = new Vector3(0, 0, 0);
            }
            if (Input.GetKey("up"))
            {
                RB.velocity = new Vector3(0, 0, 5f);
            }
            if (Input.GetKeyUp("up"))
            {
                RB.velocity = new Vector3(0, 0, 0);
            }
            if (Input.GetKey("right"))
            {
                RB.velocity = new Vector3(5f, 0, 0);
            }
            if (Input.GetKeyUp("right"))
            {
                RB.velocity = new Vector3(0, 0, 0);
            }
            if (Input.GetKey("down"))
            {
                RB.velocity = new Vector3(0, 0, -5f);
            }
            if (Input.GetKeyUp("down"))
            {
                RB.velocity = new Vector3(0, 0, 0);
            }
            if (Input.GetKey("left"))
            {
                RB.velocity = new Vector3(-5f, 0, 0);
            }
            if (Input.GetKeyUp("left"))
            {
                RB.velocity = new Vector3(0, 0, 0);
            }
        }
    }
}
