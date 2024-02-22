using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballGuy : MonoBehaviour
{
    public SpriteRenderer Spritething;
    Rigidbody2D Rigi;
    public float speed = 5000;

    

    // Start is called before the first frame update
    void Start()
    {
        Spritething = GetComponent<SpriteRenderer>();
        Selected(false);
        Rigi = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    

    private void OnMouseDown()
    {
        TheController.SetSelectedPlayer(this);
    }

    public void Selected(bool IsSelected)
    {
        if (IsSelected)
        {
            Spritething.color = Color.white;
        }
        else
        {
            Spritething.color = Color.red;
        }

    }


    public void Move(Vector2 direction)
    {
        Rigi.AddForce(direction * speed);
        //Debug.Log("eii");

    }


}
