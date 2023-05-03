using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Timer_script : MonoBehaviour
{
    public float timer = 0f;

    public void Starttimer()
    {
        timer += Time.deltaTime;
        //SKa flyttas
        //float avrundadtid = (float)Math.Round(timer, 2);
    }
    
}
