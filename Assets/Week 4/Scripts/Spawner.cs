using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject plane;
    public float Timer = 0;
    float SpawnSeconds;


    // Start is called before the first frame update
    void Start()
    {
        SpawnSeconds = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= SpawnSeconds)
        {
            Instantiate (plane,transform.position, transform.rotation);
            Timer = 0;
            SpawnSeconds = Random.Range(1, 5);
        }


    }


}
