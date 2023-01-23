using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class Camera_Perspective : MonoBehaviour
{
    
    public Camera[] cam_perspective;
    
    int current_camera;
    
    // Funktionen stänger av alla kameror i en array och sätter igång den första som är primär.
    public void Fixed_Perspective()
    {
        current_camera = 0;
        for (int i = 0; i < cam_perspective.Length; i++)
        {
            cam_perspective[i].gameObject.SetActive(false);
        }
        cam_perspective[0].gameObject.SetActive(true);
    }
    // Funktionen byter kamera och stänger av den ena som inte används genom att addera med 1 till en variabel som anger nuvarande camera.
    // Därefter så startar den om från början om man klickar en gång till och återgår till första kameran.
    public void Perspective_Change()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            cam_perspective[current_camera].gameObject.SetActive(false);
            current_camera = (current_camera + 1) % cam_perspective.Length;
            cam_perspective[current_camera].gameObject.SetActive(true);
        }
        
    }
}
