using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using spawnpositions;
using spel_move;

public class spelare : MonoBehaviour
{
    spelare_spawns current_pos;
    spelare_movement move;

    // Start is called before the first frame update
    void Start()
    {
        current_pos = GetComponent<spelare_spawns>();
        current_pos.position();
        move.kub_movement();
        

    }

    // Update is called once per frame
    void Update()
    {
        move.movement();
    }
}
