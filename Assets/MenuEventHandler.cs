using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEventHandler : MonoBehaviour
{
    public void loadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName); // adds a public string so this script can be used across many scenes, this just allows me to load a scene on an interaction with the UI
    }

    public void quitGame()
    {
        Application.Quit(); // this quits the game.
    }
}
