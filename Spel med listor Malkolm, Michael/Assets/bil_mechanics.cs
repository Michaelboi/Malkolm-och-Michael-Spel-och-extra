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
        
        float Styrinput;
        float gasinput;
        bool BilBromms;
        float styrAngle;

        // V = v�nster H = h�ger
        WheelCollider framV_hjulCollide;
        WheelCollider framH_hjulCollide;
        WheelCollider bakV_hjulCollide;
        WheelCollider bakH_hjulCollide;

        Transform framV_hjulTransform;
        Transform framH_hjulTransform;
        Transform bakV_hjulTransform;
        Transform bakH_hjulTransform;

        float motor_kraft;
        float bromms_Kraft;
        float maxstyrAngle;
        


        // funktion som tar inputs fr�n spelaren, h�r kan man ocks� �ndra vilken knapp som g�r vad
        public void bil_movement()
        {
            // Horizontal och Vertical �r mellan v�rderna -1 och 1.
            Styrinput = Input.GetAxis("Horizontal");
            gasinput = Input.GetAxis("Vertical");
            Bil_motor();
            bil_styrhjul();
            Updatehjul();

        }
        // motorTorque/brakeTorque �r en inbyggd funktion som helt enkelt till�ter hjulen att rulla och brommsa.
        // H�r la jag in mina inputs och v�rden. Den s�tter ocks� vissa specifika hjul som prim�ra som d� k�r/rullar.
        public void Bil_motor()
        {
            framH_hjulCollide.motorTorque = gasinput * motor_kraft;
            framV_hjulCollide.motorTorque = gasinput * motor_kraft;
            
            
        }
        public void Bromms()
        {
            // s�tter ig�ng brommsen och saktar ner bilen genom att f� hjulen att stanna
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
        
        // Anv�nds f�r att styra bilen samt s�tta en gr�ns f�r hur mycket den kan styra �t h�ger och v�nster
        public void bil_styrhjul()
        {
            styrAngle = maxstyrAngle * Styrinput;
            framH_hjulCollide.steerAngle = styrAngle;
            framV_hjulCollide.steerAngle = styrAngle;

        }
        // Tv� unktioner som tillsammans till�ter hjulen att snurra, den roterar allts� bara hjulen n�r en knapp �r nedtryckt men funktionen som tar knapp inputs �r h�gre upp
        // F�r att f�rtydliga, Update funktion g�r tar hjulen och st�nger av v�rderna n�r de inte anv�nds med (out).
        public void Updatehjul()
        {
            Update_Alla_hjul(framH_hjulCollide, framH_hjulTransform);
            Update_Alla_hjul(framV_hjulCollide, framV_hjulTransform);
            Update_Alla_hjul(bakH_hjulCollide, bakH_hjulTransform);
            Update_Alla_hjul(bakV_hjulCollide, bakV_hjulTransform);

        }
        // Quaternion �r f�r rotation
        // out st�nger av v�rderna p� ett s�tt d� den inte �r aktiv eller d� n�r v�rdena inte �ndras.
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
