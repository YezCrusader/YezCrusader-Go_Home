// ----------------------------------------------------------------------
// -------------------- 3D Object Carry
// -------------------- David Dorrington, UEL Games, 2019
// ----------------------------------------------------------------------
using UnityEngine;
using System.Collections;

public class DD_3D_Object_Carry : MonoBehaviour
{
    // ----------------------------------------------------------------------
    public float fl_distance = 2;
    public GameObject go_PC;
    public bool bl_carrying;
    private Rigidbody rb_attached;

    // ----------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        if (GetComponent<Rigidbody>() != null) rb_attached = GetComponent<Rigidbody>();
        if (!go_PC) go_PC = GameObject.FindGameObjectWithTag("Player");
      
    }//-----

    // ----------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        // In trigger distance
        if (Vector3.Distance(go_PC.transform.position, transform.position) < fl_distance)
        {          

            if (Input.GetKeyDown("f") && !bl_carrying)
            {
                bl_carrying = true;
             
                // child this object to the target and postition it in front
                if (rb_attached) rb_attached.isKinematic = true;
                transform.position = go_PC.transform.position + go_PC.transform.TransformDirection(0, 0, 1.2F);
                transform.rotation = go_PC.transform.rotation;
                transform.parent = go_PC.transform;
            }
            else if (Input.GetKeyDown("f") && bl_carrying)
            {  //drop the object              
                transform.parent = null;
                if (rb_attached) rb_attached.isKinematic = false;
                bl_carrying = false;
            }
        }
        
    }//-----

}//=====
