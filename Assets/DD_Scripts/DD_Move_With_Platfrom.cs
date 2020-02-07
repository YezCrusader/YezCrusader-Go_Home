using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_Move_With_Platfrom : MonoBehaviour
{

    private Transform tr_original_parent;
    
    // Start is called before the first frame update
    void Start()
    {
        tr_original_parent = transform.parent;


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        print("trigger");

        if (other.tag == "Moving")
            transform.parent = other.gameObject.transform;

    }


    private void OnTriggerExit(Collider other)
    {
        transform.parent = tr_original_parent;

    }

}
