// ----------------------------------------------------------------------
// -------------------- 3D Checkpoint
// -------------------- David Dorrington, UEL Games, 2017
// ----------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_3D_Checkpoint : MonoBehaviour 
{
    public bool bl_destoy_when_hit = true;

 // ----------------------------------------------------------------------
    // Detect if something enters the Trigger
    void OnTriggerStay (Collider _cl_collider)
    {     
        if (_cl_collider.gameObject.tag == "Player")
        {   // update the PC respawn postition
            _cl_collider.GetComponent<DD_3D_PC_Health>().v3_respawn_position = transform.position;

            if(bl_destoy_when_hit) Destroy(gameObject);
        }		
	}//-----
}//==========
