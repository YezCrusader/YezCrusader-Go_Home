// ----------------------------------------------------------------------
// -------------------- 3D Hit Text Control
// -------------------- David Dorrington, UEL Games, 2019
// ----------------------------------------------------------------------
using UnityEngine;
using System.Collections;

public class DD_3D_Hit_Text : MonoBehaviour {

    public float fl_life_time = 1;
    public float fl_speed = 2;
    

	// Use this for initialization
	void Start () {

        Destroy(gameObject, fl_life_time);
      //  transform.LookAt(GameObject.Find("Main Camera").transform.position);

	}//-----
	
	// Update is called once per frame
	void Update () {

        transform.Translate(0, fl_speed * Time.deltaTime, 0);	

	}//-----

}//==========
