using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_Bomb : MonoBehaviour
{

    // ----------------------------------------------------------------------
    // Variables
    public float fl_range = 5;
    public float fl_damage = 100F;
    public float fl_delay = 5;
    private float fl_attack_time;
    public GameObject go_hit_text;


    // -----------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        fl_attack_time = Time.time + fl_delay;
        // Call Showcount every second
        InvokeRepeating("ShowCount", 0, 1);

    }//-----

    // -----------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        // Show blast area .5 secs before explosion
        if (Time.time > fl_attack_time - 0.5F)
            transform.localScale = new Vector3(fl_range, fl_range, fl_range);

        // Activate bomb
        if (Time.time > fl_attack_time)
        {
            FindTargets();
            Destroy(gameObject);
        }
    }//-----


    // -----------------------------------------------------------------
    void ShowCount()
    {
        // Create text mesh to show countdown
        GameObject _go_hit_text = Instantiate(go_hit_text, transform.position + Vector3.up, transform.rotation) as GameObject;
        _go_hit_text.GetComponent<TextMesh>().text = Mathf.Round(fl_attack_time - Time.time).ToString();
        _go_hit_text.GetComponent<TextMesh>().color = Color.red;
    }//-----

    // -----------------------------------------------------------------
    void FindTargets()
    {
        // Search of all objects in range 
        Collider[] _col_hits = Physics.OverlapSphere(transform.position, fl_range);

        // loop through all and send damage
        foreach (Collider _col_hit in _col_hits)
        {
            _col_hit.SendMessage("Damage", fl_damage, SendMessageOptions.DontRequireReceiver);
        }

    }//------

}//==========

