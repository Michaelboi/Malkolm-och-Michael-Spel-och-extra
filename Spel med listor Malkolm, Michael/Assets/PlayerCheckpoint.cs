using bil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    public GameObject mållinje;
    public GameObject[] Checkpoints = new GameObject[8];
    public GameObject Bilreset;
    
    public int collectedpoints = 0;
    void Update()
    {
        if (collectedpoints == 8)
        {
            mållinje.SetActive(true);
        }
        Checkpoints_Spawn();

    }
    public void Checkpoints_Spawn()
    {
        if (collectedpoints < 0)
        {
            collectedpoints = 0;
        }
        if (Input.GetKey(KeyCode.R))
        {
            Bilreset.transform.position = Checkpoints[collectedpoints - 1].transform.position;
            Bilreset.transform.rotation = Checkpoints[collectedpoints - 1].transform.rotation;
            
        }
    }
    public void OnTriggerEnter(Collider Kollision)
    {
        if (Kollision.gameObject.CompareTag("mål"))
        {
            mållinje.SetActive(false);
            collectedpoints = 0;
            for (int i = 0; i < Checkpoints.Length; i++)
            {
                Checkpoints[i].SetActive(true);
            }
        }

        if (Kollision.gameObject.CompareTag("Checkpoint"))
        {
            this.collectedpoints += 1;
            Debug.Log("Checkpoint! " + collectedpoints + "/8");
            Kollision.gameObject.SetActive(false);
            
            
        }
    }
}
