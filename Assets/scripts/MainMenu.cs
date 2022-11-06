using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        // load the first level
        Application.LoadLevel(1);
    }

    public void QuitGame()
    {
        // quit the game
        Application.Quit();
    }


}