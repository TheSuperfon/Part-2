using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditor.Build;

public class TeleporterScript : MonoBehaviour
{

    public bool nextLetter;
    public bool nextnextLetter;
    public GameObject TheU;
    public GameObject TheN;

    // Start is called before the first frame update
    void Start()
    {
        nextLetter = false;
        nextnextLetter = false;
        TheU.SetActive(false);
        TheN.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            nextLetter = true;
            TheU.SetActive(true);
        }
        if (nextLetter == true)
        {
            if (Input.GetKeyDown("u"))
            {
                nextnextLetter = true;
                TheN.SetActive(true);
            }

        }
        if (nextnextLetter == true)
        {
            if (Input.GetKeyDown("n"))
            {
                LoadNewScene();
            }

        }


    }

    private void LoadNewScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }

}
