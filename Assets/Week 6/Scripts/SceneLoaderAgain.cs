using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderAgain : MonoBehaviour
{
    


    public void LoadKnightGame()
    {
        SceneManager.LoadScene(3);
        
    }
    public void sixteenByNine()
    {
        
        Screen.SetResolution(1680,1050,false);
    }


    public void FullHDScreen()
    {
        Screen.SetResolution(1920,1080,false);
        
    }





}
