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
    public GameObject PlayerCharacter;
    
    
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
        
        
        
    }


    private void OnMouseDown()
    {
        TargetsScoreReference.SendMessage("ScoreUpdates", 1);
        
        PlayerCharacter.SendMessage("ShootAnimation");


        //Debug.Log("neat");
    }

    private void OnMouseUp()
    {
        //PlayerCharacter.SendMessage("ShootAnimation");
    }





}
