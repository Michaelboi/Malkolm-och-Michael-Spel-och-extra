using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor.Search;
using UnityEngine;

public class power_up : MonoBehaviour
{
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
        //ShowAndHide();
        //ska skaffa parkiklar som kommer när man åker igenom powerupen
        // Ge en effekt till spelaren
    }
    ///public IEnumerator snopp()
    //{
    //gameObject.SetActive(false);
    //yield return new WaitForSeconds(3);
    //gameObject.SetActive(true)\\\
    //}
}
