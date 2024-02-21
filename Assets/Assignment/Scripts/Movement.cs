using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    Rigidbody2D Rigibody;
    public float speed = 5;
    Animator animate;
    Vector2 location;
    Vector2 move;
    public bool stopmoving;
    public float MovementMultiplier;
    public GameObject ScoreReference;
    public GameObject StationaryReference;
    public GameObject MovingShotReference;



    // Start is called before the first frame update
    void Start()
    {
        Rigibody = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        stopmoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(MovementMultiplier);
        if (stopmoving == false)
        {//learned how to do point and click movememnt from week 5 and edited to fit the cowboy game
            if (Input.GetMouseButtonDown(0))
            {
                location = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            animate.SetFloat("Movement", move.magnitude);
        }
        if (animate.GetFloat("Movement") > 0)
        {
            //MovementMultiplier = 2;
            ScoreReference.SendMessage("ScoreMultiples", 2);
            StationaryReference.SetActive(false);
            MovingShotReference.SetActive(true);
        }
        else
        {
            //MovementMultiplier = 1;
            ScoreReference.SendMessage("ScoreMultiples", 1);
            StationaryReference.SetActive(true);
            MovingShotReference.SetActive(false);
        }

        
    }

    private void FixedUpdate()
    {

        move = location - (Vector2)transform.position; 

        if(move.magnitude < 0.1)
        {
            move = Vector2.zero; //stops cowboy's movement when reached position
        }

        Rigibody.MovePosition(Rigibody.position +  move.normalized * speed * Time.deltaTime);
        
        

        
    }

    




}
