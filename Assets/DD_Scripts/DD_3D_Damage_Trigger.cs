using UnityEngine;
using System.Collections;

public class DD_3D_Damage_Trigger : MonoBehaviour
{
    public float fl_damage = 50;

    // ----------------------------------------------------------------------
    // Detect if something enters the Trigger
    void OnTriggerStay(Collider _cl_collider)
    {
        _cl_collider.gameObject.SendMessage("Damage", Time.deltaTime * fl_damage, SendMessageOptions.DontRequireReceiver);

    }//------

}//------

