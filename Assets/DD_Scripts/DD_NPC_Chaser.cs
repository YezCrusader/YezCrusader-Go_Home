// ----------------------------------------------------------------------
// -------------------- 3D NPC Chaser
// -------------------- David Dorrington, UEL Games, 2019
// ----------------------------------------------------------------------
using UnityEngine;
using System.Collections;

public class DD_NPC_Chaser : MonoBehaviour
{
    // ----------------------------------------------------------------------
    // Combat Variables
    public GameObject go_projectile;
    public float fl_attack_range = 20;
    public float fl_cool_down = 1;
    public Vector3 v3_fire_offset = new Vector3(0, 0.5F, 0.5F);
    public string st_target_class = "Player";
    private float fl_delay;

    // Movement
    public bool bl_chase = true;
    public float fl_chase_dist_max = 10;
    public float fl_chase_dist_min = 3;
    public float fl_chase_speed = 3;

    public GameObject go_home;
    public GameObject go_target;
    private CharacterController cc_NPC;

    // ----------------------------------------------------------------------

    // Use this for initialization
    void Start()
    {
        cc_NPC = GetComponent<CharacterController>();

        // if no target is set find the first tagged as the enemy
        if (!go_target)
            go_target = GameObject.FindWithTag(st_target_class);
    }//-----

    // ----------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
       
            if (bl_chase)
            {
                NPC_Move();
            }
            AttackTarget();
        
    }//-----

    // ----------------------------------------------------------------------
    void NPC_Move()
    {
        // Is the target in Range
        if (Vector3.Distance(transform.position, go_target.transform.position) < fl_chase_dist_max)
        {   // Face the Target
            transform.LookAt(go_target.transform.position);

            if (Vector3.Distance(transform.position, go_target.transform.position) > fl_chase_dist_min)
            {   // Move towards the target
                cc_NPC.SimpleMove(fl_chase_speed * transform.TransformDirection(Vector3.forward));
            }
        }
        else if (go_home) // is there a home object set
        {
            if (Vector3.Distance(transform.position, go_home.transform.position) > fl_chase_dist_min * 2)
            {
                // Head Home
                transform.LookAt(go_home.transform.position);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                cc_NPC.SimpleMove(fl_chase_speed * transform.TransformDirection(Vector3.forward));
            }
        }
        else
        {  // stop moving
            cc_NPC.SimpleMove(Vector3.zero);
        }
    }//-----


    // ----------------------------------------------------------------------
    void AttackTarget()
    {
        if (Time.time > fl_delay && Vector3.Distance(transform.position, go_target.transform.position) < fl_attack_range)
        {
            // Face the Target
            transform.LookAt(go_target.transform.position);

            // Spawn an arrow     
            Instantiate(go_projectile, transform.position + transform.TransformDirection(v3_fire_offset), transform.rotation);

            //Reset Cooldown
            fl_delay = Time.time + fl_cool_down;
        }
    }//------

  

}//==========
