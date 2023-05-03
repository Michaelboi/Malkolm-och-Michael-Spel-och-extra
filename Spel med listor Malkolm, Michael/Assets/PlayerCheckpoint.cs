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
    public float avrundadtid;
    public int collectedpoints = 0;
    public float timer = 0f;
    void Update()
    {
        timer += Time.deltaTime;
        if (collectedpoints == 8)
        {
            mållinje.SetActive(true);
        }
        Checkpoints_Spawn();

    }
    public void Checkpoints_Spawn()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Bilreset.transform.position = Checkpoints[collectedpoints - 1].transform.position;
            Bilreset.transform.rotation = Checkpoints[collectedpoints - 1].transform.rotation;

        }
        if (collectedpoints < 0)
        {
            collectedpoints = 0;
        }
        
    }
    public void OnTriggerEnter(Collider Kollision)
    {
        if (Kollision.gameObject.CompareTag("mål"))
        {
            mållinje.SetActive(false);
            avrundadtid = (float)Math.Round(timer, 2);
            Debug.Log(avrundadtid + "sekunder");
            timer = 0f;
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
