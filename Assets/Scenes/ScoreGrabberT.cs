using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreGrabberT : MonoBehaviour
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
        score = GameMechanic.triggerScore;

        updateGUI();

        bool buttonStart = OVRInput.Get(OVRInput.RawButton.Start);

        //makes the start button load the menu
        if(buttonStart == true)
        {
            SceneManager.LoadScene("TargetShootMenu");
        }
    }

    void updateGUI()
    {

        string buffer = "Final Score: " + score + "\nWant to Play again? ";
        gameData.text = buffer; 
    }
}