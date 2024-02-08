using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{

    public GameObject Weapon;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnWeapon()
    {
        Instantiate(Weapon, transform.position, transform.rotation);


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
