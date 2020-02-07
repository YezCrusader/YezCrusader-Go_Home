using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_PC_Range_Attack : MonoBehaviour {

    // Range Weapon Variables
    public float fl_damage = 10;
    public float fl_cooldown = 1F;
    public float fl_accuracy = 100;
    public int in_ammo = 1000;
    public int in_max_ammo = 1000;
    private float fl_next_attack_time;   

    // GameObjects 
    public GameObject GO_projectile;    



    // ----------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {        
            Attack();       
    }//-----  
         
    // ----------------------------------------------------------------------
    void Attack()
    {
        if (Input.GetButton("Fire1") && Time.time > fl_next_attack_time && in_ammo > 0)
        {   // Reset the cooldown delay
            fl_next_attack_time = Time.time + fl_cooldown;
            // Reduce Ammo;
            in_ammo--;
            // Create Projectile slightly to the right and in front of the PC using the camera Rotation
            GameObject _GO_projectile_clone = Instantiate(GO_projectile, transform.position + transform.TransformDirection(new Vector3(0.25f, 0f, 1.5F)), transform.rotation);
            // Create a random rotation based on accuracy
            Vector3 _V3_accuracy_offset = new Vector3(Random.Range(-100 + fl_accuracy, 100 - fl_accuracy) / 5, Random.Range(-100 + fl_accuracy, 100 - fl_accuracy) / 5, 0);
            _GO_projectile_clone.transform.Rotate(_V3_accuracy_offset);
        }
    }//-----

    // ----------------------------------------------------------------------
    // Ammo Pickup Receiver
    public void Ammo(int _in_ammo)
    {   // add the ammo picked up to current ammo limitted to the max value
        in_ammo += _in_ammo;
        if (in_ammo > in_max_ammo) in_ammo = in_max_ammo;
    }//------  

}//===========
