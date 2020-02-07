using UnityEngine;
using System.Collections;

public class DD_Platform_Move : MonoBehaviour
{
    // ----------------------------------------------------------------------
    // Variables
    private Vector3 v3_start_position;
    private Vector3 v3_end_position;
    public Vector3 v3_travel_distance = new Vector3(0, 5, 0);
    public float fl_speed = 1;
    private bool bl_forward = true;
    private float fl_path_length;
    private float fl_start_time;

    // ----------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        v3_start_position = transform.position;
        v3_end_position = v3_start_position + v3_travel_distance;

        fl_path_length = Vector3.Distance(v3_start_position, v3_end_position);
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
            transform.position = Vector3.Lerp(v3_start_position, v3_end_position, _fl_step);

            if (Vector3.Distance(transform.position, v3_end_position) < 0.1F)
            {
                bl_forward = false;
                // Reset Time
                fl_start_time = Time.time;
            }
        }
        else // Move to start pos
        {
            transform.position = Vector3.Lerp(v3_end_position, v3_start_position, _fl_step);
            if (Vector3.Distance(transform.position, v3_start_position) < 0.1f)
            {
                bl_forward = true;
                // Reset Time
                fl_start_time = Time.time;
            }
        }
    }//-----

}//==========