using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_3D_Moving_Platform : MonoBehaviour {

    // ----------------------------------------------------------------------
    // Variables
    public Vector3 V3_start_position;
    public Vector3 V3_end_position;
    public float fl_speed = 1;
    private bool bl_forward = true;
    private float fl_path_length;
    private float fl_start_time;

    // ----------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        fl_path_length = Vector3.Distance(V3_start_position, V3_end_position);
        fl_start_time = Time.time;
    }//-----	

    // ----------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {

        // temp movement variables
        float _fl_dist_travelled = (Time.time - fl_start_time) * fl_speed;
        float _fl_step = _fl_dist_travelled / fl_path_length;

        // Move towards end
        if (bl_forward)
        {
            transform.position = Vector3.Lerp(V3_start_position, V3_end_position, _fl_step);

            if (Vector3.Distance(transform.position, V3_end_position) < 0.1F)
            {
                bl_forward = false;
                // Reset Time
                fl_start_time = Time.time;
            }
        }
        else // Move to start pos
        {
            transform.position = Vector3.Lerp(V3_end_position, V3_start_position, _fl_step);
            if (Vector3.Distance(transform.position, V3_start_position) < 0.1f)
            {
                bl_forward = true;
                // Reset Time
                fl_start_time = Time.time;
            }
        }
    }//-----

}//==========
