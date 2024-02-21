using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float Xlocation;
    public float Ylocation;
    bool ClickingTarget;
    public GameObject TargetsScoreReference;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Xlocation = Random.Range(-8,8);    
        Ylocation = Random.Range(-4,4);

        transform.position = new Vector2(Xlocation,Ylocation);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && ClickingTarget)
        {
            
        }
        
        
    }


    private void OnMouseDown()
    {
        ClickingTarget = true;
        TargetsScoreReference.SendMessage("ScoreUpdates", 1);
    }

    private void OnMouseUp()
    {
        ClickingTarget = false;
    }





}
