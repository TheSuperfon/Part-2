using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float Xlocation;
    public float Ylocation;
    public GameObject TargetsScoreReference;
    public GameObject PlayerCharacter;
    public bool EndTheGame;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Xlocation = Random.Range(-8,8);    
        Ylocation = Random.Range(-4,4);
        EndTheGame = false;
        transform.position = new Vector2(Xlocation,Ylocation);

    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }


    private void OnMouseDown()
    {

        if (EndTheGame) return;
        TargetsScoreReference.SendMessage("ScoreUpdates", 1);
        
        PlayerCharacter.SendMessage("ShootAnimation");





        Xlocation = Random.Range(-8,8);    
        Ylocation = Random.Range(-4,4);

        transform.position = new Vector2(Xlocation,Ylocation);
        //Debug.Log("neat");
    }

    private void OnMouseUp()
    {
        //PlayerCharacter.SendMessage("ShootAnimation");
    }

    public void NoMore()
    {
        EndTheGame = true;
        
    }



}
