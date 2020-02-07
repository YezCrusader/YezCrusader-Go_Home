// ----------------------------------------------------------------------
// -------------------- 3D PC Multiple weapon system
// -------------------- David Dorrington, UEL Games, 2019
// ----------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DD_Ranged_Weapons : MonoBehaviour
{
    // ----------------------------------------------------------------------
    public static List<Weapon> Weapons;
    public static List<Ammo> Munitions;
    public static int in_current_weapon = 0;
    private float fl_next_attack_time;

    public Transform tx_weapon;
    private LineRenderer line_laser;
    private Camera go_PC_camera;

    public Text text_Ammo_HUD;
    public Text text_Arms_HUD;
    public Text text_Ammunition_HUD;

    // ----------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        line_laser = GetComponent<LineRenderer>();
        // tx_weapon = transform.Find("Gun").transform;
        go_PC_camera = GetComponentInChildren<Camera>();

        Weapons = new List<Weapon>
        {
              new Weapon() {name = "Pistol",        carrying = true, ammo_type = 0, clip_size = 10,  range = 30,   damage = 10, cool_down = 0.5F, recoil_dist = 0.1f , hit_force = 100} ,
              new Weapon() {name = "Rifle",         carrying = true, ammo_type = 0, clip_size = 30,  range = 50,   damage = 30, cool_down = 1, recoil_dist = 0.1f , hit_force = 200} ,
              new Weapon() {name = "Shotgun",       carrying = true, ammo_type = 2, clip_size = 50,  range = 15,   damage = 10, cool_down =   1f, recoil_dist = 0.1f, hit_force = 200} ,
              new Weapon() {name = "Sniper_Rifle",    carrying = true, ammo_type = 1, clip_size = 6,   range = 100,  damage = 100, cool_down = 4, recoil_dist = 0.1f , hit_force = 500} ,
              new Weapon() {name = "LMG",           carrying = true, ammo_type = 0, clip_size = 50,  range = 50,   damage = 30, cool_down = 0.2f, recoil_dist = 0.1f, hit_force = 200} ,
        };

        Munitions = new List<Ammo>
        {
            new Ammo() { name = "Bullets", current_amount = 50, max_amount = 200 },
            new Ammo() { name = "Rounds", current_amount = 5, max_amount = 10},
            new Ammo() { name = "Shells", current_amount = 25, max_amount = 50},
            new Ammo() { name = "Bombs", current_amount = 5, max_amount = 5},
        };

    }//-----


    // ---------------------------------------------------------d-------------
    private void Update()
    {
        SwitchWeapon();
        DisplayMunitions();
        FireWeapon();
    }//-----


    // Ammo Pickup receivers
    public void Bullet(int _in_amount)
    {

        Munitions[0].current_amount += _in_amount;
        if (Munitions[0].current_amount > Munitions[0].max_amount)
            Munitions[0].current_amount = Munitions[0].max_amount;
    }//-----

    // Ammo Pickup receivers
    public void Round(int _in_amount)
    {
        Munitions[1].current_amount += _in_amount;
        if (Munitions[1].current_amount > Munitions[1].max_amount)
            Munitions[1].current_amount = Munitions[1].max_amount;
    }//----

    // Ammo Pickup receivers
    public void Shell(int _in_amount)
    {
        Munitions[2].current_amount += _in_amount;
        if (Munitions[2].current_amount > Munitions[2].max_amount)
            Munitions[2].current_amount = Munitions[2].max_amount;
    }//----



    // ----------------------------------------------------------------------
    private void FireWeapon()
    {
        if (Input.GetButton("Fire1") && Munitions[Weapons[in_current_weapon].ammo_type].current_amount > 0 && Time.time > fl_next_attack_time)
        {
            if (in_current_weapon == 2) // shotgun
            {
                for (int _index = 1; _index < 12; _index++)
                {
                    FireLaser(3);
                }
            }
            else
            {
                FireLaser(0);
            }

            //Reset next shot time
            fl_next_attack_time = Time.time + Weapons[in_current_weapon].cool_down;

            // Reduce Ammo
            Munitions[Weapons[in_current_weapon].ammo_type].current_amount--;
        }
    }//-----


    // ----------------------------------------------------------------------
    public GameObject go_marker;

    private void FireLaser(float _fl_accuracy)
    {
        StartCoroutine(ShotEffect());

        // Temp Variables
        Vector3 _v3_ray_origin = go_PC_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit _hit;

        // set the line renderer start to the weapon
        line_laser.SetPosition(0, tx_weapon.position);

        Vector3 _v3_accuracy_offset = new Vector3(Random.Range(-_fl_accuracy, _fl_accuracy) / 50, Random.Range(-_fl_accuracy, _fl_accuracy) / 50, 0);

        Vector3 _v3_direction = go_PC_camera.transform.forward + go_PC_camera.transform.TransformDirection(_v3_accuracy_offset);


        // cast a ray and has it hit something
        if (Physics.Raycast(_v3_ray_origin, _v3_direction, out _hit, Weapons[in_current_weapon].range))
        {
            // Set the line renderer end position the objectr hit
            line_laser.SetPosition(1, _hit.point);

            Instantiate(go_marker, _hit.point, Quaternion.identity);

            // Send Damage to what is hit
            _hit.collider.SendMessage("Damage", Weapons[in_current_weapon].damage, SendMessageOptions.DontRequireReceiver);

            // Send force to what we hit it has a rigid body
            if (_hit.rigidbody)
                _hit.rigidbody.AddForce(-_hit.normal * Weapons[in_current_weapon].hit_force);
        }
        else
        {   // set the end of the line renderer and the range

            Vector3 _v3_end_point = _v3_ray_origin + (go_PC_camera.transform.forward) * Weapons[in_current_weapon].range;

            line_laser.SetPosition(1, _v3_end_point);
        }
    }//  -----  

    // ----------------------------------------------
    // Coroutine for displaying for laser line
    private IEnumerator ShotEffect()
    {
        //add sound fx here   
        // GetComponent<AudioSource>().Play();

        line_laser.enabled = true;
        yield return new WaitForSeconds(0.01F);
        line_laser.enabled = false;
    }//----


    // ----------------------------------------------------------------------
    private void SwitchWeapon()
    {
        if (Input.mouseScrollDelta.y < 0) // Rolled Down
        {
            fl_next_attack_time = Time.time;

            in_current_weapon++;
            if (in_current_weapon > Weapons.Count - 1) in_current_weapon = 0;
        }
        if (Input.mouseScrollDelta.y > 0) // Rolled Up
        {
            fl_next_attack_time = Time.time;

            in_current_weapon--;
            if (in_current_weapon < 0) in_current_weapon = Weapons.Count - 1;
        }


    }//-----


    // ----------------------------------------------
    private void DisplayMunitions()
    {
        text_Ammo_HUD.text = "Ammo \n" + Munitions[Weapons[in_current_weapon].ammo_type].current_amount.ToString();
        text_Arms_HUD.text = Weapons[in_current_weapon].name;

        text_Ammunition_HUD.text = "Ammunition \n";

        for (int _index = 0; _index < Munitions.Count; _index++)
        {
            text_Ammunition_HUD.text += Munitions[_index].name + "  " + Munitions[_index].current_amount + " / " + Munitions[_index].max_amount + "\n";
        }

    }//------


    // ----------------------------------------------------------------------
    // Define the ammo variables for the inventory
    public class Ammo
    {
        public string name { get; set; }
        public int current_amount { get; set; }
        public int max_amount { get; set; }
    }//----

    // ----------------------------------------------------------------------
    // Define the weapon objects variables for the inventory
    public class Weapon
    {
        public string name { get; set; }
        public bool carrying { get; set; }
        public int ammo_type { get; set; }
        public int clip_size { get; set; }
        public int range { get; set; }
        public int damage { get; set; }
        public float cool_down { get; set; }
        public float recoil_dist { get; set; }
        public float hit_force { get; set; }

    }//-----

}//==========
