using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEventHandler : MonoBehaviour
{
    public void loadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
