//---------------------------------------------------------------------------------------
// Simple Object Spawner
// David Dorrington, UEL Games, 2019
//---------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_Spawner : MonoBehaviour
{
    //---------------------------------------------------------------------------------------
    // Variables
    public GameObject go_spawnee;
    public float fl_cooldown = 1;
    public int in_spawn_total = 10;
    public float fl_start_delay = 3;
    public bool bl_infinite = true;
    public bool bl_destroy_when_done = false;  
    private float fl_next_spawn_time;

    //---------------------------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        // Set the first spawn time
        fl_next_spawn_time = fl_cooldown + Time.time + fl_start_delay;
    }//-----

    //---------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        // has the cooldown time passed
        if (Time.time > fl_next_spawn_time && (bl_infinite || in_spawn_total > 0))
        {
            // Create a clone of the spawneee at the position and rotation of this object
            Instantiate(go_spawnee, transform.position, transform.rotation);

            // Set the next spawn time
            fl_next_spawn_time = Time.time + fl_cooldown;
            
            // reduce the number of spawnees left 
            if (!bl_infinite) in_spawn_total--;            
        }
        
        // Remove this from the scene when all items are spawned
        if (bl_destroy_when_done && in_spawn_total < 1) Destroy(gameObject);
    }//-----

}//==========