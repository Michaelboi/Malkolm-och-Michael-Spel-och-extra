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
        if (Kollision.gameObject.CompareTag("mål"))
        {
            mållinje.SetActive(false);
            for (int i = 0; i < Checkpoint.Length; i++)
            {
                Checkpoint[i].gameObject.SetActive(true);

            }
            collectedpoints = 0;
        }

        if (Kollision.gameObject.CompareTag("Checkpoint"))
        {
            this.collectedpoints += 1;
            Debug.Log("Checkpoint! " + collectedpoints + "/3");
            Kollision.gameObject.SetActive(false);
            
            
        }
    }
}
