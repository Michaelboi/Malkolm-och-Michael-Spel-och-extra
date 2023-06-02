using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpointsingle : MonoBehaviour
{
    // används ej
    int Checkpointscore = 0;
    int maxScore = 3;
    public void VidKollision(Collider kollision)
    { 
        if (kollision.TryGetComponent<spelare>(out spelare bil))
        {
            Checkpointscore += 1;
            Debug.Log("Checkpoint " + Checkpointscore + "/3");
        }
        if (Checkpointscore > maxScore)
        {
            Checkpointscore = 0;
        }
    }

}
