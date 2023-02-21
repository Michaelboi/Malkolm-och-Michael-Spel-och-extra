using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bil
{
    public class bil_mechanics : MonoBehaviour
    {

        // olika variabler som används för att brommsa, sätta värde för hur mycket kraft den brommsas med och styrningen.
        public float maxTorque;
        public float Styrinput;
        public float gasinput;
        public bool BilBromms;
        public float styrAngle;

        // V = vänster H = höger
        public WheelCollider framV_hjulCollide;
        public WheelCollider framH_hjulCollide;
        public WheelCollider bakV_hjulCollide;
        public WheelCollider bakH_hjulCollide;

        public Transform framV_hjulTransform;
        public Transform framH_hjulTransform;
        public Transform bakV_hjulTransform;
        public Transform bakH_hjulTransform;

        public float motor_kraft;
        public float bromms_Kraft;
        public float maxstyrAngle;

        public Rigidbody respawnvelocity;
        


        // funktion som tar inputs från spelaren, här kan man också ändra vilken knapp som gör vad
        public void bil_movement()
        {
            // Horizontal och Vertical är mellan värderna -1 och 1.
            Styrinput = Input.GetAxis("Horizontal");
            gasinput = Input.GetAxis("Vertical");
            Bil_motor();
            bil_styrhjul();
            Updatehjul();
            if (Input.GetKey(KeyCode.R))
            {
                respawnvelocity.velocity = new Vector3(0, 0, 0);
            }
            

        }
        // motorTorque/brakeTorque är en inbyggd funktion som helt enkelt tillåter hjulen att rulla och brommsa.
        // Här la jag in mina inputs och värden. Den sätter också vissa specifika hjul som primära som då kör/rullar.
        public void Bil_motor()
        {
            bakH_hjulCollide.motorTorque = gasinput * motor_kraft;
            bakV_hjulCollide.motorTorque = gasinput * motor_kraft;
            framH_hjulCollide.motorTorque = gasinput * motor_kraft;
            framV_hjulCollide.motorTorque = gasinput * motor_kraft;

            /*if (bakH_hjulCollide.motorTorque < maxTorque)
            {
                bakH_hjulCollide.motorTorque = gasinput * motor_kraft;
                bakV_hjulCollide.motorTorque = gasinput * motor_kraft;
                framH_hjulCollide.motorTorque = gasinput * motor_kraft;
                framV_hjulCollide.motorTorque = gasinput * motor_kraft;
            }
            if (framV_hjulCollide.motorTorque < maxTorque)
            {
                bakH_hjulCollide.motorTorque = gasinput * motor_kraft;
                bakV_hjulCollide.motorTorque = gasinput * motor_kraft;
                framH_hjulCollide.motorTorque = gasinput * motor_kraft;
                framV_hjulCollide.motorTorque = gasinput * motor_kraft;
            }
            if (framH_hjulCollide.motorTorque < maxTorque)
            {
                bakH_hjulCollide.motorTorque = gasinput * motor_kraft;
                bakV_hjulCollide.motorTorque = gasinput * motor_kraft;
                framH_hjulCollide.motorTorque = gasinput * motor_kraft;
                framV_hjulCollide.motorTorque = gasinput * motor_kraft;
            }
            if (bakV_hjulCollide.motorTorque < maxTorque)
            {
                bakH_hjulCollide.motorTorque = gasinput * motor_kraft;
                bakV_hjulCollide.motorTorque = gasinput * motor_kraft;
                framH_hjulCollide.motorTorque = gasinput * motor_kraft;
                framV_hjulCollide.motorTorque = gasinput * motor_kraft;
            }
            if (Input.GetKey(KeyCode.R))
            {
                framV_hjulCollide.motorTorque = 0;
                framH_hjulCollide.motorTorque = 0;
                bakH_hjulCollide.motorTorque = 0;
                bakV_hjulCollide.motorTorque = 0;
            }*/


        }
        public void Bromms()
        {
            // sätter igång brommsen och saktar ner bilen genom att få hjulen att stanna
            if (Input.GetKey(KeyCode.LeftShift))
            {
                BilBromms = true;
            }
            else
            {
                BilBromms = false;
            }

            if (BilBromms == true)
            {
                framH_hjulCollide.brakeTorque = bromms_Kraft;
                framV_hjulCollide.brakeTorque = bromms_Kraft;
                bakH_hjulCollide.brakeTorque = bromms_Kraft;
                bakV_hjulCollide.brakeTorque = bromms_Kraft;
            }
            else
            {
                framH_hjulCollide.brakeTorque = 0;
                framV_hjulCollide.brakeTorque = 0;
                bakH_hjulCollide.brakeTorque = 0;
                bakV_hjulCollide.brakeTorque = 0;
            }
        }
        
        // Används för att styra bilen samt sätta en gräns för hur mycket den kan styra åt höger och vänster
        public void bil_styrhjul()
        {
            styrAngle = maxstyrAngle * Styrinput;
            framH_hjulCollide.steerAngle = styrAngle;
            framV_hjulCollide.steerAngle = styrAngle;

        }
        // Två unktioner som tillsammans tillåter hjulen att snurra, den roterar alltså bara hjulen när en knapp är nedtryckt men funktionen som tar knapp inputs är högre upp
        // För att förtydliga, Update funktion gör tar hjulen och stänger av värderna när de inte används med (out).
        public void Updatehjul()
        {
            Update_Alla_hjul(framH_hjulCollide, framH_hjulTransform);
            Update_Alla_hjul(framV_hjulCollide, framV_hjulTransform);
            Update_Alla_hjul(bakH_hjulCollide, bakH_hjulTransform);
            Update_Alla_hjul(bakV_hjulCollide, bakV_hjulTransform);

        }
        // Quaternion är för rotation
        // out stänger av värderna på ett sätt då den inte är aktiv eller då när värdena inte ändras.
        private void Update_Alla_hjul(WheelCollider hjulcollide, Transform hjultransform)
        {
            Vector3 postion;
            Quaternion rotation;
            hjulcollide.GetWorldPose(out postion, out rotation);
            hjultransform.rotation = rotation;
            hjultransform.position = postion;
            
        }
    }

}
