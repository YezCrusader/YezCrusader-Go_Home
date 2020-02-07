// ----------------------------------------------------------------------
// -------------------- 3D NPC Chase 
// -------------------- David Dorrington, UEL Games, 2019
// ----------------------------------------------------------------------
using UnityEngine;
using System.Collections;

public class DD_3D_Trigger_Send_Message : MonoBehaviour
{
    // ----------------------------------------------------------------------
    public string st_property = "Health";
    public int in_value = 50;

    // ----------------------------------------------------------------------
    // Detect if something enters the Trigger
    void OnTriggerEnter (Collider _cl_collider)
    {     
        if (_cl_collider.gameObject.tag == "Player")
        {
            _cl_collider.gameObject.SendMessage(st_property, in_value, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }//------

}//==========
