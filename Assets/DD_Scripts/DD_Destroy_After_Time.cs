using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_Destroy_After_Time : MonoBehaviour
{


    public float fl_time_alive = 1;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, fl_time_alive);    
    }

}
