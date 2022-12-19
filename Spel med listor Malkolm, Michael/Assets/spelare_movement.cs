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
        public float move_speed = 5;
        public float max_speed = 20;
        public Vector3 move_input;
        public void kub_movement()
        {
            RB = GetComponent<Rigidbody>();
            
            
        }

        // input för att spelaren ska kunna röra sig höger, vänster, fram, bak och uppåt
        public void movement()
        {
            move_input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            RB.drag = (move_speed / max_speed);
            RB.AddForce(move_input * move_speed);
            

            if (Input.GetButtonDown("Jump"))
            {
                RB.velocity = new Vector3(RB.velocity.x, 5f, RB.velocity.z);
                
            }
        }
    }
}
