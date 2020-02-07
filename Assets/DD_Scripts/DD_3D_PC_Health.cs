// ----------------------------------------------------------------------
// -------------------- 3D PC Health
// -------------------- David Dorrington, UEL Games, 2019
// ----------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DD_3D_PC_Health : MonoBehaviour
{
    // ----------------------------------------------------------------------
    public Vector3 v3_respawn_position;
    public float fl_HP = 100;
    public float fl_max_HP = 100;

    public GameObject go_hit_text;
    public Text tx_health;
    private Transform tr_HP_bar;
    // private CharacterController cc_PC;

    // ----------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        tr_HP_bar = gameObject.transform.Find("HP_Bar");

        // Set initial respawn position
        v3_respawn_position = transform.position;
    }//-----

    // ----------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        ResizeBar();
        DisplayHealth();
    }//-----

    // ----------------------------------------------------------------------
    void DisplayHealth()
    {
        tx_health.text = fl_HP.ToString();
    }




    // ----------------------------------------------------------------------
    // Resize the HP Bar
    void ResizeBar()
    {   // is there an HP bar attached
        if (tr_HP_bar)
        {   // Resize and colour the bar based on current HP
            tr_HP_bar.localScale = new Vector3((fl_HP / fl_max_HP), 0.1F, 0.1F);
            if (fl_HP > fl_max_HP / 2) tr_HP_bar.GetComponent<Renderer>().material.color = Color.green;
            if (fl_HP > fl_max_HP / 4 && fl_HP < fl_max_HP / 2) tr_HP_bar.GetComponent<Renderer>().material.color = Color.yellow;
            if (fl_HP < fl_max_HP / 4) tr_HP_bar.GetComponent<Renderer>().material.color = Color.red;
        }
    }//-----

    // ----------------------------------------------------------------------
    // 
    void CheckHealth()
    {
        if (fl_HP <= 0) // health depleted
        {
            transform.position = v3_respawn_position;
            fl_HP = fl_max_HP;
        }
    }//------

    // ----------------------------------------------------------------------
    // Damage Receiver
    public void Damage(float _fl_damage)
    {
        // Subtract the damage sent from HP
        fl_HP -= _fl_damage;
        // Create text mesh to show hit damage
        GameObject _GO_hit_text = Instantiate(go_hit_text, transform.position + Vector3.up, transform.rotation) as GameObject;
        _GO_hit_text.GetComponent<TextMesh>().text = _fl_damage.ToString();
        _GO_hit_text.GetComponent<TextMesh>().color = Color.red;
    }//-----

    // ----------------------------------------------------------------------
    // Health Receiver
    public void Health(float _fl_health)
    {
        // Add the health pichup to HP
        fl_HP += _fl_health;
        // Create text mesh to show health
        GameObject _GO_hit_text = Instantiate(go_hit_text, transform.position + Vector3.up, transform.rotation) as GameObject;
        _GO_hit_text.GetComponent<TextMesh>().text = _fl_health.ToString();
        _GO_hit_text.GetComponent<TextMesh>().color = Color.green;
    }//-----

}//==========