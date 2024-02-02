using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runway : MonoBehaviour
{
    public float score = 0;
    GameObject planeObject;
    
    //public Transform planetransform;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        planeObject = collision.gameObject;



        if (collision.OverlapPoint(transform.position))
        {
            //Debug.Log("hi");
            planeObject.GetComponent<Plane>().disapear = true;
        }


    }

}
