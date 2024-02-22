using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    Rigidbody2D BallBody;
    



    // Start is called before the first frame update
    void Start()
    {
        BallBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.transform.position = Vector2.zero;
        TheController.ScoreNumber += 1;
        BallBody.velocity = Vector2.zero;

    }


}
