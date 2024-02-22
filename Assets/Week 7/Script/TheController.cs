using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TheController : MonoBehaviour
{
    public Slider ChargeSlider;
    float charge;
    public float maxCharge = 1;
    Vector2 direction;

    public static float ScoreNumber;
    public TextMeshProUGUI ScoreUI;

    public void Start()
    {
        ScoreNumber = 0;
    }


    public static FootballGuy SelectedPlayer {  get; private set; }
    public static void SetSelectedPlayer(FootballGuy Player)
    {
        if(SelectedPlayer != null)
        {
            SelectedPlayer.Selected(false);
        }
        SelectedPlayer = Player;
        SelectedPlayer.Selected(true);
    }


    private void FixedUpdate()
    {
        if(direction != Vector2.zero)
        {
            SelectedPlayer.Move(direction);
            //Debug.Log(direction);
            direction = Vector2.zero;
            charge = 0;
            ChargeSlider.value = charge;
        }
    }


    private void Update()
    {

        ScoreUI.text = ScoreNumber.ToString();

        if (SelectedPlayer == null) return;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            charge = 0;
            direction = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            charge += Time.deltaTime;
            charge = Mathf.Clamp(charge, 0, maxCharge);
            ChargeSlider.value = charge;



        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)SelectedPlayer.transform.position).normalized * charge;
        }
    }


    



}
