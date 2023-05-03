using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using spawnpositions;
using spel_move;
using bil;

public class spelare : MonoBehaviour
{
    spelare_spawns current_pos;
    //spelare_movement move;
    bil_mechanics bil_move;
    Camera_Perspective Camera_switch;
    public Rigidbody bilrigidbody;
    
    





    // Start is called before the first frame update
    void Awake()
    {
        bilrigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
        // Här används GetComponent för att variabeln från klassen ska fungera, dvs att den tar information från den klassen
        //move = GetComponent<spelare_movement>();
        Camera_switch = GetComponent<Camera_Perspective>();
        current_pos = GetComponent<spelare_spawns>();
        bil_move = GetComponent<bil_mechanics>();
        current_pos.position();
        Camera_switch.Fixed_Perspective();
        //move.kub_movement();


    }

    // Update is called once per frame
    void Update()
    {
        //move.movement();
        Camera_switch.Perspective_Change();
        bil_move.bil_movement();
       
        
    }
    void FixedUpdate()
    {
        bil_move.Bromms();

    }
    
}
