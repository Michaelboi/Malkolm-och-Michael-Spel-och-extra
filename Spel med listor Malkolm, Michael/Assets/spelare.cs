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

    // Start is called before the first frame update
    
    void Start()
    {
        // H?r anv?nds GetComponent f?r att variabeln fr?n klassen ska fungera, dvs att den tar information fr?n den klassen
        //move = GetComponent<spelare_movement>();
        current_pos = GetComponent<spelare_spawns>();
        bil_move = GetComponent<bil_mechanics>();
        current_pos.position();
        //move.kub_movement();


    }

    // Update is called once per frame
    void Update()
    {
        //move.movement();
        bil_move.bil_movement();
    }
    void FixedUpdate()
    {
        bil_move.Bromms();
    }
}
