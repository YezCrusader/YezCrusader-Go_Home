// ----------------------------------------------------------------------
// -------------------- 3D Bloodlock
// -------------------- David Dorrington, UEL Games, 2019
// ----------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_3D_Bloodlock : MonoBehaviour {

    // Variables
    public GameObject[] go_Activators;
    public GameObject go_target_object;
    public bool bl_enable;

    //---------------------------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        // Disable the target object if we are to enable it
        if (bl_enable) go_target_object.SetActive(false);
    }//-----

    //---------------------------------------------------------------------------------------
    // Update is called once per frame
    void FixedUpdate()
    {
        // local variable of total number of activation objects we started with
        int _in_objects_left = go_Activators.Length;

        // loop through the list of activation objects
        foreach (GameObject _go in go_Activators)
        {
            // subtract 1 from the total if the gameobject has been destroyed
            if (!_go) _in_objects_left--;
        }

        // Are all the objects destroyed?
        if (_in_objects_left < 1)
        {
            if (bl_enable) // are we enabling or disabling the target object
                go_target_object.SetActive(true);
            else
                go_target_object.SetActive(false);
        }
    }//-----

}//==========