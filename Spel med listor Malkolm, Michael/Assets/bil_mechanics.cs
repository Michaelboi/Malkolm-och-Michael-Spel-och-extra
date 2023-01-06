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
        
        public float Styrinput;
        public float gasinput;
        public bool BilBromms;
        public float current_brommsKraft;
        public float styrAngle;

        // V = v�nster H = h�ger
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
        


        // funktion som tar inputs fr�n spelaren, h�r kan man ocks� �ndra vilken knapp som g�r vad
        public void bil_movement()
        {
            
            Styrinput = Input.GetAxis("Horizontal");
            gasinput = Input.GetAxis("Vertical");
            BilBromms = Input.GetKeyDown(KeyCode.LeftShift);
            Bil_motor();
            bil_styrhjul();
            Updatehjul();

        }
        // anv�nds f�r att ta bilens hjul ska kunna k�ra. Den s�tter ocks� vissa specifika hjul som prim�ra som d� k�r/rullar.
        private void Bil_motor()
        {
            framH_hjulCollide.motorTorque = gasinput * motor_kraft;
            framV_hjulCollide.motorTorque = gasinput * motor_kraft;
            current_brommsKraft = BilBromms ? bromms_Kraft : 0f;
            if (BilBromms == true)
            {
                L�ggBromms();
            }
            
        }
        // s�tter ig�ng brommsen och saktar ner bilen genom att f� hjulen att stanna
        private void L�ggBromms()
        {
            framH_hjulCollide.brakeTorque = current_brommsKraft;
            framV_hjulCollide.brakeTorque = current_brommsKraft;
            bakH_hjulCollide.brakeTorque = current_brommsKraft;
            bakV_hjulCollide.brakeTorque = current_brommsKraft;
            
        }
        // Anv�nds f�r att styra bilen samt s�tta en gr�ns f�r hur mycket den kan styra �t h�ger och v�nster
        private void bil_styrhjul()
        {
            styrAngle = maxstyrAngle * Styrinput;
            framH_hjulCollide.steerAngle = styrAngle;
            framV_hjulCollide.steerAngle = styrAngle;

        }
        // Tv� unktioner som tillsammans till�ter hjulen att snurra, den roterar allts� bara hjulen n�r en knapp �r nedtryckt men funktionen som tar knapp inputs �r h�gre upp
        private void Updatehjul()
        {
            Update_Allahjul(framH_hjulCollide, framH_hjulTransform);
            Update_Allahjul(framV_hjulCollide, framV_hjulTransform);
            Update_Allahjul(bakH_hjulCollide, bakH_hjulTransform);
            Update_Allahjul(bakV_hjulCollide, bakV_hjulTransform);

        }
        // Quaternion �r f�r rotation
        // out st�nger av v�rderna p� ett s�tt d� den inte �r aktiv eller d� n�r v�rdena inte �ndras.
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
