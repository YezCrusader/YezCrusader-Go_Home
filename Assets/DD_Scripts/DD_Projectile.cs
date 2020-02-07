// ----------------------------------------------------------------------
// -------------------- 3D Projectile
// -------------------- David Dorrington, UEL Games, 2018
// ----------------------------------------------------------------------
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class DD_Projectile : MonoBehaviour
{

    // ----------------------------------------------------------------------
    // Variables
    public float fl_range = 20;
    public float fl_speed = 10;
    public float fl_damage = 10;
    public bool bl_use_Trigger = true;

    // ----------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        // Remove this bullet from the scene when the range is met
        Destroy(this.gameObject, fl_range / fl_speed);
        GetComponent<Rigidbody>().velocity = fl_speed * transform.TransformDirection(Vector3.forward);

        if (bl_use_Trigger)
            GetComponent<Collider>().isTrigger = true;
    } //-----	

    // ----------------------------------------------------------------------
    // Send Damage Message

    void OnCollisionEnter(Collision _col_object_hit)
    {
        _col_object_hit.collider.gameObject.SendMessage("Damage", fl_damage, SendMessageOptions.DontRequireReceiver);
        Destroy(this.gameObject);
    }//-----

    private void OnTriggerStay(Collider _cl_object_hit)
    {
        _cl_object_hit.gameObject.SendMessage("Damage", fl_damage, SendMessageOptions.DontRequireReceiver);
        Destroy(this.gameObject);
    }//-----

}//==========
