using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class power_up : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        //kollar om den som kolliderar med oblektet har tagen bil
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }
    //är en funktion som kommer plocka upp powerupen
    public void Pickup()
    {
        Debug.Log("puss");
        //ska skaffa parkiklar som kommer när man åker igenom powerupen
        // Ge en effekt till spelaren
        // Ta bort objektet under en viss period
        gameObject.SetActive(false);
        //Task.Delay(5);gameObject.SetActive(true);
      
        Thread.Sleep(3000);
        gameObject.SetActive(true);

    }

}
