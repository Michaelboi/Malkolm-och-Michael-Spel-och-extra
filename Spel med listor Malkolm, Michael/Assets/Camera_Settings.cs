using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Settings : MonoBehaviour
{
    void FixedUpdate()
    {
        Main_Camera();
    }
    // De h�r variablerna s�tter kamerans avst�nd fr�n bilen och hur snabbt kameran f�ljer efter den.
    Vector3 offset;
    float smoothtransitionSpeed;
    Transform target;
    Vector3 rotateoffset;
    float camrotateSpeed;

    // Jag har anv�nt n�gra inbyggda funktioner som anv�nds f�r att f�rflytta kameran och f�lja bilen.
    public void Main_Camera()
    {
        // Den h�r g�r att den �r insatt till att f�lja bilen. Den tar ocks� bilens poistioner.
        // Nu f�ljer kameran bilen med en hastighet p� hur snabbt den kan hinna till baka till
        // original position som den hade med bilen.
        Vector3 targetpos = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetpos, smoothtransitionSpeed * Time.deltaTime);
        
        //Den h�r l�ter kameran rotera lite n�r bilen sv�nger s� att den inte �r helt fastbunden vid en riktning
        Vector3 riktning = target.position - transform.position;
        Quaternion rotate = Quaternion.LookRotation(riktning + rotateoffset, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotate, camrotateSpeed * Time.deltaTime);
    }

}
