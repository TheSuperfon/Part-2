using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheController : MonoBehaviour
{
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





}
