using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_3D_Trigger_Colour_Swap : MonoBehaviour {

    //-------------------------------------------------------------------------
    private Renderer rn_attached;
    public Color col_highlight = Color.cyan;
    private Color col_original;

    //-------------------------------------------------------------------------
    // Use this for initialization
	void Start () 
    {// find the attached render and store the original colour
        rn_attached = GetComponent<Renderer>();
        col_original = rn_attached.material.color;
    }//-----

    //-------------------------------------------------------------------------
    void OnTriggerEnter( Collider _cl_detected)
    {
        // if we are hit by the PC swap Colour
        if (_cl_detected.tag == "Player")
            rn_attached.material.color = col_highlight;
    }//-----

    //-------------------------------------------------------------------------
    void OnTriggerExit(Collider _cl_detected)
    {
       //Reset the colour to the original
        if (_cl_detected.tag == "Player")
            rn_attached.material.color = col_original;
    }//-----
        
    //-------------------------------------------------------------------------
    // Swapping colours on trigger
    // David Dorrington, UELGames 2017
}//================

