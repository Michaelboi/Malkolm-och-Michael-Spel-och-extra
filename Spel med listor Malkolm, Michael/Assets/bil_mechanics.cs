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
        
        public float horizontalInput;
        public float verticalInput;
        public bool BilBromms;
        public float current_brommsKraft;
        public float styrAngle;

        // V = vänster H = höger
        // SerializeField behövs för att referera alla dessa variabler
        [SerializeField] public WheelCollider framV_hjulCollide;
        [SerializeField] public WheelCollider framH_hjulCollide;
        [SerializeField] public WheelCollider bakV_hjulCollide;
        [SerializeField] public WheelCollider bakH_hjulCollide;

        [SerializeField] public Transform framV_hjulTransform;
        [SerializeField] public Transform framH_hjulTransform;
        [SerializeField] public Transform bakV_hjulTransform;
        [SerializeField] public Transform bakH_hjulTransform;

        [SerializeField] public float hjul_Kraft;
        [SerializeField] public float bromms_Kraft;
        [SerializeField] public float maxstyrAngle;
        


        // funktion som tar inputs från spelaren, här kan man också ändra vilken knapp som gör vad
        public void bil_movement()
        {
            
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            BilBromms = Input.GetKey(KeyCode.LeftShift);
            Bil_motor();
            bil_styrhjul();
            Updatehjul();

        }
        // används för att ta bilens hjul ska kunna köra. Den sätter också vissa specifika hjul som primära som då kör/rullar.
        private void Bil_motor()
        {
            framH_hjulCollide.motorTorque = verticalInput * hjul_Kraft;
            framV_hjulCollide.motorTorque = verticalInput * hjul_Kraft;
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
            styrAngle = maxstyrAngle * horizontalInput;
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
