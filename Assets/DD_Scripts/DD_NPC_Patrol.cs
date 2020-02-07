// ----------------------------------------------------------------------
// -------------------- 3D NPC Waypoint Patrol 
// -------------------- David Dorrington, UEL Games, 2017
// ----------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_NPC_Patrol : MonoBehaviour
{

    // ----------------------------------------------------------------------
    // Combat Variables
    public GameObject GO_projectile;
    public float fl_range = 15;
    public float fl_cool_down = 1;
    private float fl_next_shot_time;   

    // Movement
    public GameObject[] GOS_waypoints;
    public float fl_speed = 3;
    private int in_next_wp = 0;

    public GameObject GO_target;
    private CharacterController CC_NPC;

    // ----------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {   // Find the Game Objects we need to interact with
        CC_NPC = GetComponent<CharacterController>();
        // if no target is set find the first tagged as the enemy
        if (!GO_target)
            GO_target = GameObject.FindWithTag("Player");
    }//-----

    // ----------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, GO_target.transform.position) < fl_range)
        {
            AttackTarget();
        }
        else
        {
            Patrol();
        }
    }//-----

    // ----------------------------------------------------------------------
    void Patrol()
    {
        //Are there any waypoints defined?
        if (GOS_waypoints.Length > 0)
        {   // Look at the next WP
            transform.LookAt(GOS_waypoints[in_next_wp].transform.position);

            // Move towards the WP
            CC_NPC.SimpleMove(fl_speed * transform.TransformDirection(Vector3.forward));

            // if we get close move to WP target the next
            if (Vector3.Distance(GOS_waypoints[in_next_wp].transform.position, transform.position) < 1)
            {
                if (in_next_wp < GOS_waypoints.Length - 1)
                    in_next_wp++;
                else
                    in_next_wp = 0;
            }
        }
    }//-----


    // ----------------------------------------------------------------------
    void AttackTarget()
    {
        // Does the NPC have ammo and has the cooldown passed
        if (Time.time > fl_next_shot_time)
        {
            // Face the Target
            transform.LookAt(GO_target.transform.position);
            CC_NPC.SimpleMove(Vector3.zero);

            // Spawn a projectile   
            Instantiate(GO_projectile, transform.position + transform.TransformDirection(new Vector3(0, 0, 1F)), transform.rotation);

            fl_next_shot_time = Time.time + fl_cool_down;
        }
    }//------

}//==========