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
        public float maxTorque;
        public float Styrinput;
        public float gasinput;
        public bool BilBromms;
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

        public Rigidbody respawnvelocity;
        


        // funktion som tar inputs fr�n spelaren, h�r kan man ocks� �ndra vilken knapp som g�r vad
        public void bil_movement()
        {
            // Horizontal och Vertical �r mellan v�rderna -1 och 1.
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
        // motorTorque/brakeTorque �r en inbyggd funktion som helt enkelt till�ter hjulen att rulla och brommsa.
        // H�r la jag in mina inputs och v�rden. Den s�tter ocks� vissa specifika hjul som prim�ra som d� k�r/rullar.
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
