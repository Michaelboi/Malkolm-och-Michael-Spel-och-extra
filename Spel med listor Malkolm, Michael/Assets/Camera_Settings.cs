using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Settings : MonoBehaviour
{
    // De här variablerna sätter kamerans avstånd från bilen och hur snabbt kameran följer efter den.
    public Transform bil;
    public Vector3 offset;
    public float smoothtransitionSpeed = 1;
    public Transform target;
    public float camrotateSpeed;

    // Jag har använt några inbyggda funktioner som används för att förflytta kameran och följa bilen.
    public void Main_Camera()
    {
        // Den här gör att den är insatt till att följa bilen. Den tar också bilens poistioner.
        // Nu följer kameran bilen med en hastighet på hur snabbt den kan hinna till baka till
        // original position som den hade med bilen.
        Vector3 camerapos = bil.position + offset;
        Vector3 camerafölj = Vector3.Lerp(transform.position, camerapos, smoothtransitionSpeed);
        transform.position = camerafölj;
        transform.rotation = Quaternion.Lerp(transform.rotation, bil.rotation, camrotateSpeed);
        

        /*Vector3 targetpos = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetpos, smoothtransitionSpeed * Time.deltaTime);*/

        // Den här låter kameran rotera lite när bilen svänger så att den inte är helt fastbunden vid en riktning
        /*Vector3 riktning = target.position - transform.position;
        Quaternion rotate = Quaternion.LookRotation(riktning, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotate, camrotateSpeed * Time.deltaTime);*/
    }

}
