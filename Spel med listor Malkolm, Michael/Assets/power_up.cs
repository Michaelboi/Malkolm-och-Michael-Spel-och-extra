using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor.Search;
using UnityEngine;

public class power_up : MonoBehaviour
{
    public float duration = 3f;
    void Start()
    {
        //StartCoroutine(ShowAndHide());
       
    }

    public void OnTriggerEnter(Collider other)
    {

        
        //kollar om den som kolliderar med oblektet har tagen bil
        if (other.CompareTag("Player"))
        {
            Pickup();
            gameObject.SetActive(false);
            Invoke("ReactivateObject", 3f);
        }
    }
    private void ReactivateObject()
    {
        gameObject.SetActive(true);
    }
    //är en funktion som kommer plocka upp powerupen
    public void Pickup()
    {
        Debug.Log("puss");

        // Ge en effekt till spelaren
        // Ge effekten under en viss tid sedan återgå till normal
        //yield return new WaitForSeconds(duration);
    }
   
}
