//---------------------------------------------------------------------------------------
// Simple 3D Object Move and Rotate 
// David Dorrington, UEL Games, 2019
//---------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_3D_Object_Move_Rotate : MonoBehaviour
{
    //-----------------------------------------------------------------------------------
    // Variables - public so they can be modified in the inspector 
    public Vector3 v3_velocity;
    public Vector3 v3_rotation;

    //------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        // Move the object this script is attached to
        transform.Translate(v3_velocity * Time.deltaTime);

        // Rotate the object this script is attached to
        transform.Rotate(v3_rotation * Time.deltaTime);

    }//-----

}//==========
