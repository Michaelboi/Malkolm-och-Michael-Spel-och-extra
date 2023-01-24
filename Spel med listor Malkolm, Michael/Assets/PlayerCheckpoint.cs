using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{

    public GameObject[] Checkpoint;

    
    // Update is called once per frame

    public void OnTriggerEnter(Collider Kollision)
    {

        if (Kollision.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log("Checkpoint!");
            Checkpoint[0].gameObject.SetActive(false);
            
            
        }
    }
}
