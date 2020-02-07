// ----------------------------------------------------------------------
// -------------------- 3D Drop object when this is destroyed
// -------------------- David Dorrington, UEL Games, 2019
// ----------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_3D_Drop_Object_On_Destroy : MonoBehaviour
{
    // ----------------------------------------------------------------------
    public GameObject go_drop_object;

    // ----------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        // Initially turn off the object 
        go_drop_object.SetActive(false);

    }//------

    private void OnDestroy()
    {
        // Enable the object to drop
        if (go_drop_object) go_drop_object.SetActive(true);
    }//------

}//==========
