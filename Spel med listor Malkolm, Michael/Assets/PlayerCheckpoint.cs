using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    public GameObject mållinje;
    public GameObject[] Checkpoint = new GameObject[3];
    public int collectedpoints = 0;
    void Update()
    {
        if (collectedpoints == 3)
        {
            mållinje.SetActive(true);
        }

    }
    public void OnTriggerEnter(Collider Kollision)
    {

        if (Kollision.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log("Checkpoint!");
            Kollision.gameObject.SetActive(false);
            this.collectedpoints += 1;
            Debug.Log(collectedpoints);
            
        }
    }
}
