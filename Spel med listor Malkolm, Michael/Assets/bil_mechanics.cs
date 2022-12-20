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
        public float current_brommsForce;
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

        [SerializeField] public float hjul_Force;
        [SerializeField] public float bromms_Force;
        [SerializeField] public float maxstyrAngle;


        // funktion som sätter  olika inputs
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
        void Bil_motor()
        {
            framH_hjulCollide.motorTorque = horizontalInput * hjul_Force;
            framV_hjulCollide.motorTorque = horizontalInput * hjul_Force;
            current_brommsForce = BilBromms ? bromms_Force : 0f;
            if (BilBromms)
            {
                LäggBromms();
            }
        }
        // sätter igång brommsen och saktar ner bilen genom att få hjulen att stanna
        void LäggBromms()
        {
            framH_hjulCollide.brakeTorque = current_brommsForce;
            framV_hjulCollide.brakeTorque = current_brommsForce;
            bakH_hjulCollide.brakeTorque = current_brommsForce;
            bakV_hjulCollide.brakeTorque = current_brommsForce;
        }
        // Används för att styra bilen samt sätta en gräns för hur mycket den kan styra åt höger och vänster
        void bil_styrhjul()
        {
            styrAngle = maxstyrAngle * horizontalInput;
            framH_hjulCollide.steerAngle = styrAngle;
            framV_hjulCollide.steerAngle = styrAngle;

        }
        // Två unktioner som tillsammans tillåter hjulen att snurra, den roterar alltså bara hjulen när en knapp är nedtryckt men funktionen som tar knapp inputs är högre upp
        void Updatehjul()
        {
            Updateallahjul(framH_hjulCollide, framH_hjulTransform);
            Updateallahjul(framV_hjulCollide, framV_hjulTransform);
            Updateallahjul(bakH_hjulCollide, bakH_hjulTransform);
            Updateallahjul(bakV_hjulCollide, bakV_hjulTransform);

        }
        // Quaternion är för rotation
        // out stänger av värderna på ett sätt då den inte är aktiv eller då när värdena inte ändras.
        void Updateallahjul(WheelCollider hjulcollide, Transform hjultransform)
        {
            Vector3 postion;
            Quaternion rotation;
            hjulcollide.GetWorldPose(out postion, out rotation);
            hjultransform.rotation = rotation;
            hjultransform.position = postion;
        }
    }

}
