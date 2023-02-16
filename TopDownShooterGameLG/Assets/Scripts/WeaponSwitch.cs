using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{ 
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;

    public KeyCode switchWeapon;

    int weaponId = 0;

    bool shotgunActive;
    bool sniperActive;
    bool smgActive;

    // Start is called before the first frame update
    void Start()
    {
        shotgunActive = false;
        sniperActive = false;
        smgActive = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(switchWeapon))
        {
            weaponId++;
        }

        if (weaponId == 0)
        {
            weapon1.SetActive(true);
            weapon2.SetActive(false);
            weapon3.SetActive(false);
            weapon4.SetActive(false);
        }


        if (weaponId == 1 && sniperActive == true)
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true);
            weapon3.SetActive(false);
            weapon4.SetActive(false);

        }



        if (weaponId == 2 && shotgunActive == true)
        {
            weapon1.SetActive(false);
            weapon2.SetActive(false);
            weapon3.SetActive(true);
            weapon4.SetActive(false);
        }



        if (weaponId == 3 && smgActive == true)
        {
            weapon1.SetActive(false);
            weapon2.SetActive(false);
            weapon3.SetActive(false);
            weapon4.SetActive(true);
        }


        if (weaponId == 4)
        {
            weaponId = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shotgun")
        {
            Debug.Log("Shotgun Picked Up!");
            shotgunActive = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Sniper")
        {
            Debug.Log("Sniper Picked Up!");
            sniperActive = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Smg")
        {
            Debug.Log("SMG Picked up!");
            smgActive = true;
            Destroy(other.gameObject);
        }
    }

}
