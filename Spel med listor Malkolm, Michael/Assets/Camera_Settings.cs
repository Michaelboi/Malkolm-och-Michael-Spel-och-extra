using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Settings : MonoBehaviour
{
    // De h�r variablerna s�tter kamerans avst�nd fr�n bilen och hur snabbt kameran f�ljer efter den.
    public Transform bil;
    public Vector3 offset;
    public float smoothtransitionSpeed = 1;
    public Transform target;
    public float camrotateSpeed;

    // Jag har anv�nt n�gra inbyggda funktioner som anv�nds f�r att f�rflytta kameran och f�lja bilen.
    public void Main_Camera()
    {
        // Den h�r g�r att den �r insatt till att f�lja bilen. Den tar ocks� bilens poistioner.
        // Nu f�ljer kameran bilen med en hastighet p� hur snabbt den kan hinna till baka till
        // original position som den hade med bilen.
        Vector3 camerapos = bil.position + offset;
        Vector3 cameraf�lj = Vector3.Lerp(transform.position, camerapos, smoothtransitionSpeed);
        transform.position = cameraf�lj;
        transform.rotation = Quaternion.Lerp(transform.rotation, bil.rotation, camrotateSpeed);
        

        /*Vector3 targetpos = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetpos, smoothtransitionSpeed * Time.deltaTime);*/

        // Den h�r l�ter kameran rotera lite n�r bilen sv�nger s� att den inte �r helt fastbunden vid en riktning
        /*Vector3 riktning = target.position - transform.position;
        Quaternion rotate = Quaternion.LookRotation(riktning, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotate, camrotateSpeed * Time.deltaTime);*/
    }

}
