using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_Trigger_Objects_Enable : MonoBehaviour
{
    // ----------------------------------------------------------------------
    // Variables in this script
    public GameObject[] go_targets;
    public GameObject go_trigger;
    public bool bl_destroy_trigger_when_activated;
    public float fl_delay;
    public bool bl_enable;
    private float fl_trigger_time;
    private bool bl_triggered;

    // ----------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        // Set the Target objects to disabled if we are to enable it on the trigger 
        if (bl_enable)
        {
            foreach (GameObject _go in go_targets)
            {
                _go.SetActive(false);
            }
        }

        GetComponent<Renderer>().materials[0].DisableKeyword("_EMISSION");


    }//-----

    // ----------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        // If the trigger has been activated swap the target state after the time delay
        if (bl_triggered && Time.time > fl_trigger_time)
        {
            if (bl_enable)
            {
                foreach (GameObject _go in go_targets)
                {
                    _go.SetActive(true);
                }
            }
            else
            {
                foreach (GameObject _go in go_targets)
                {
                    _go.SetActive(false);
                }
            }

            //Destroy this object when complete 
            if (bl_destroy_trigger_when_activated) Destroy(gameObject);
        }
    }//-----  

    // ----------------------------------------------------------------------
    // Detect if something enters the Trigger
    void OnTriggerEnter(Collider cl_trigger)
    {
        // Is the trigger the correct trigger GameObject 
        if (cl_trigger.gameObject == go_trigger)
        {
            // Set the trigger flag
            bl_triggered = true;

            // Set the time delay
            fl_trigger_time = Time.time + fl_delay;

            GetComponent<Renderer>().materials[0].EnableKeyword("_EMISSION");
        }
    }//-----

    //-------------------------------------------------------------------------
    // Enabling or Disbale object on Trigger
    // David Dorrington, UELGames 2017
}//================

