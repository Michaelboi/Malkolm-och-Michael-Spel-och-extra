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
        
        public float Styrinput;
        public float gasinput;
        public bool BilBromms;
        public float current_brommsKraft;
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
        


        // funktion som tar inputs från spelaren, här kan man också ändra vilken knapp som gör vad
        public void bil_movement()
        {
            
            Styrinput = Input.GetAxis("Horizontal");
            gasinput = Input.GetAxis("Vertical");
            BilBromms = Input.GetKeyDown(KeyCode.LeftShift);
            Bil_motor();
            bil_styrhjul();
            Updatehjul();

        }
        // används för att ta bilens hjul ska kunna köra. Den sätter också vissa specifika hjul som primära som då kör/rullar.
        private void Bil_motor()
        {
            framH_hjulCollide.motorTorque = gasinput * motor_kraft;
            framV_hjulCollide.motorTorque = gasinput * motor_kraft;
            current_brommsKraft = BilBromms ? bromms_Kraft : 0f;
            if (BilBromms == true)
            {
                LäggBromms();
            }
            
        }
        // sätter igång brommsen och saktar ner bilen genom att få hjulen att stanna
        private void LäggBromms()
        {
            framH_hjulCollide.brakeTorque = current_brommsKraft;
            framV_hjulCollide.brakeTorque = current_brommsKraft;
            bakH_hjulCollide.brakeTorque = current_brommsKraft;
            bakV_hjulCollide.brakeTorque = current_brommsKraft;
            
        }
        // Används för att styra bilen samt sätta en gräns för hur mycket den kan styra åt höger och vänster
        private void bil_styrhjul()
        {
            styrAngle = maxstyrAngle * Styrinput;
            framH_hjulCollide.steerAngle = styrAngle;
            framV_hjulCollide.steerAngle = styrAngle;

        }
        // Två unktioner som tillsammans tillåter hjulen att snurra, den roterar alltså bara hjulen när en knapp är nedtryckt men funktionen som tar knapp inputs är högre upp
        private void Updatehjul()
        {
            Update_Allahjul(framH_hjulCollide, framH_hjulTransform);
            Update_Allahjul(framV_hjulCollide, framV_hjulTransform);
            Update_Allahjul(bakH_hjulCollide, bakH_hjulTransform);
            Update_Allahjul(bakV_hjulCollide, bakV_hjulTransform);

        }
        // Quaternion är för rotation
        // out stänger av värderna på ett sätt då den inte är aktiv eller då när värdena inte ändras.
        private void Update_Allahjul(WheelCollider hjulcollide, Transform hjultransform)
        {
            Vector3 postion;
            Quaternion rotation;
            hjulcollide.GetWorldPose(out postion, out rotation);
            hjultransform.rotation = rotation;
            hjultransform.position = postion;
        }
    }

}
