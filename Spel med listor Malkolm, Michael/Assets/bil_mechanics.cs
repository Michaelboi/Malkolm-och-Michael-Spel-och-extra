using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bil
{
    public class bil_mechanics : MonoBehaviour
    {
        // olika variabler som anv�nds f�r att brommsa, s�tta v�rde f�r hur mycket kraft den brommsas med och styrningen.
        public float horizontalInput;
        public float verticalInput;
        public bool BilBromms;
        public float current_brommsForce;
        public float styrAngle;

        // V = v�nster H = h�ger
        // SerializeField beh�vs f�r att referera alla dessa variabler
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


        // funktion som s�tter  olika inputs
        public void bil_movement()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            BilBromms = Input.GetKey(KeyCode.LeftShift);
            Bil_motor();
            bil_styrhjul();
            Updatehjul();

        }
        // anv�nds f�r att ta bilens hjul ska kunna k�ra. Den s�tter ocks� vissa specifika hjul som prim�ra som d� k�r/rullar.
        void Bil_motor()
        {
            framH_hjulCollide.motorTorque = horizontalInput * hjul_Force;
            framV_hjulCollide.motorTorque = horizontalInput * hjul_Force;
            current_brommsForce = BilBromms ? bromms_Force : 0f;
            if (BilBromms)
            {
                L�ggBromms();
            }
        }
        // s�tter ig�ng brommsen och saktar ner bilen genom att f� hjulen att stanna
        void L�ggBromms()
        {
            framH_hjulCollide.brakeTorque = current_brommsForce;
            framV_hjulCollide.brakeTorque = current_brommsForce;
            bakH_hjulCollide.brakeTorque = current_brommsForce;
            bakV_hjulCollide.brakeTorque = current_brommsForce;
        }
        // Anv�nds f�r att styra bilen samt s�tta en gr�ns f�r hur mycket den kan styra �t h�ger och v�nster
        void bil_styrhjul()
        {
            styrAngle = maxstyrAngle * horizontalInput;
            framH_hjulCollide.steerAngle = styrAngle;
            framV_hjulCollide.steerAngle = styrAngle;

        }
        // Tv� unktioner som tillsammans till�ter hjulen att snurra, den roterar allts� bara hjulen n�r en knapp �r nedtryckt men funktionen som tar knapp inputs �r h�gre upp
        void Updatehjul()
        {
            Updateallahjul(framH_hjulCollide, framH_hjulTransform);
            Updateallahjul(framV_hjulCollide, framV_hjulTransform);
            Updateallahjul(bakH_hjulCollide, bakH_hjulTransform);
            Updateallahjul(bakV_hjulCollide, bakV_hjulTransform);

        }
        // Quaternion �r f�r rotation
        // out st�nger av v�rderna p� ett s�tt d� den inte �r aktiv eller d� n�r v�rdena inte �ndras.
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
