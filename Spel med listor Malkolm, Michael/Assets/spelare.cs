using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using spawnpositions;
using spel_move;
using bil;

public class spelare : MonoBehaviour
{
    spelare_spawns current_pos;
    spelare_movement move;
    bil_mechanics bil_move;

    // Start is called before the first frame update
    
    void Start()
    {
        // Här används GetComponent för att variabeln från klassen ska fungera
        move = GetComponent<spelare_movement>();
        current_pos = GetComponent<spelare_spawns>();
        current_pos.position();
        move.kub_movement();


    }

    // Update is called once per frame
    void Update()
    {
        move.movement();
        
    }
    void FixedUpdate()
    {
        bil_move.bil_movement();
    }
}
