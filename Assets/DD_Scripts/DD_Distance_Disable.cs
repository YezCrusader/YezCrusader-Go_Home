//-------------------------------------------------------------------------
// Destroy Game Object when activator is close
// David Dorrington, UELGames 2019

using UnityEngine;
using System.Collections;

public class DD_Distance_Disable : MonoBehaviour
{
    public GameObject go_activator;
    public float fl_distance;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position , go_activator.transform.position) < fl_distance)
        {
            Destroy(gameObject);
        }
    }//--------
}//==============
