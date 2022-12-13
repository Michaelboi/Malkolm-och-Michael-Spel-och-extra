using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using spawnpositions;
using spel_move;

public class spelare : MonoBehaviour
{
    player_spawns current_pos;
    player_movement move;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        current_pos = GetComponent<player_spawns>();
        current_pos.position();
        move.GetComponent<player_movement>();
        move.kub_movement();

    }

    // Update is called once per frame
    void Update()
    {
        move.movement();
    }
}
