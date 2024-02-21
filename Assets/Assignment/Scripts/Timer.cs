using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject PlayerCharacter;
    public GameObject Target;
    public GameObject MenuButton;
    public TextMeshProUGUI ActualTimer;
    public float Codetimer;
    public bool StopTimer;


    // Start is called before the first frame update
    void Start()
    {
        ActualTimer = GetComponent<TextMeshProUGUI>();
        Codetimer = 30;
        StopTimer = false;
        MenuButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (StopTimer == true)
        {
            Codetimer = 0;
            MenuButton.SetActive(true);
        }


        if (StopTimer == false)
        {
            Codetimer -= Time.deltaTime;
        }

        


        ActualTimer.text = Codetimer.ToString();
        
        if (Codetimer <= 0)
        {
            if (StopTimer) return;
            


            PlayerCharacter.SendMessage("EndPose");
            Target.SendMessage("NoMore");




            StopTimer = true;
            Codetimer = 0;
        }




    }
}
