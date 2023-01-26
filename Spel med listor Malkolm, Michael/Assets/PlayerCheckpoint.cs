using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    public GameObject m�llinje;
    public GameObject[] Checkpoint = new GameObject[3];
    public int collectedpoints = 0;
    void Update()
    {
        if (collectedpoints == 3)
        {
            m�llinje.SetActive(true);
        }


    }
    public void OnTriggerEnter(Collider Kollision)
    {
        if (Kollision.gameObject.CompareTag("m�l"))
        {
            m�llinje.SetActive(false);
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
