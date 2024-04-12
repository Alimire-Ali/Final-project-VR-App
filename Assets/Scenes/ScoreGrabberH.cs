using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreGrabberH : MonoBehaviour
{
    [Header("Game Score")]
    public TMP_Text gameData;
    private static int score;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        score = HoopCollision.hoopScore; // gets the score from the game and adds it to this script

        updateGUI();

        bool buttonStart = OVRInput.Get(OVRInput.RawButton.Start);

        //makes the start button load the menu
        if(buttonStart == true)
        {
            SceneManager.LoadScene("HoopShootMenu");
        }
    }

    void updateGUI()
    {

        string buffer = "Final Score: " + score + "\nWant to Play again? "; // displays score and allows user to go back to the menu
        gameData.text = buffer; 
    }
}
