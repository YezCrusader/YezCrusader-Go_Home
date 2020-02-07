using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DD_NPC_NM : MonoBehaviour
{
    // ----------------------------------------------------------------------
    public enum en_states { Idle, Attack, Recharge };
    public en_states NPC_state = en_states.Idle;
    private Transform tx_target;
    private UnityEngine.AI.NavMeshAgent nm_agent;

    public float fl_HP = 100;
    public float fl_HP_Max = 100;
    public float fl_chase_range = 15;
    public float fl_attack_range = 10;
    // Combat
    public float fl_cool_down = 1;
    private float fl_next_shot_time;
    public GameObject go_projectile;

    // ----------------------------------------------------------------------
    void Start()
    {
        nm_agent = GetComponent<NavMeshAgent>();
        tx_target = GameObject.FindGameObjectWithTag("Player").transform;
    }//-----

    // ----------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        SwitchStates();
        UpdateHP();

    }//-----

    // ----------------------------------------------------------------------
    private void SwitchStates()
    {
        if (fl_HP < 30) NPC_state = en_states.Recharge;

        switch (NPC_state)
        {
            case en_states.Idle:
                Idle();
                break;
            case en_states.Recharge:
                RechargeHP();
                break;
            case en_states.Attack:
                AttackEnemy();
                break;
        }
    }//-----


    // ----------------------------------------------------------------------
    void Idle()
    {
        if (Vector3.Distance(transform.position, tx_target.position) < fl_chase_range)
            NPC_state = en_states.Attack;
        
    }//-----


    // ----------------------------------------------------------------------
    private void AttackEnemy()
    {
        // Set Target
        nm_agent.SetDestination(tx_target.position);

        // Fire at target
        if (Vector3.Distance(transform.position, nm_agent.destination) < fl_attack_range)
        {
            if (fl_next_shot_time < Time.time)
            {
                Instantiate(go_projectile, transform.position + transform.TransformDirection(new Vector3(0, 0, 1.5F)), transform.rotation);

                fl_next_shot_time = Time.time + fl_cool_down;
            }
        }

    }//-----



    // ----------------------------------------------------------------------
    private void RechargeHP()
    {
        nm_agent.SetDestination(GameObject.Find("Home").transform.position);
        if (fl_HP > 60) NPC_state = en_states.Attack;

    }//-----


    // ---------------------------------------------------------------------
    private void UpdateHP()
    {
        GetComponentInChildren<TextMesh>().text = Mathf.Round(fl_HP).ToString();
        if (fl_HP > fl_HP_Max) fl_HP = fl_HP_Max;

    }//-----

    // ----------------------------------------------------------------------
    public void Damage(float fl_damage)
    {
        fl_HP -= fl_damage;

    }//----

}//========
