using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballGuy : MonoBehaviour
{
    public SpriteRenderer Spritething;



    // Start is called before the first frame update
    void Start()
    {
        Spritething = GetComponent<SpriteRenderer>();
        Selected(false);
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

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


}
