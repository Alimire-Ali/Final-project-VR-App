using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMechanic : MonoBehaviour
{
    [Header("Game Score")]
    public TMP_Text gameData; //how to put the score data into the UI

    public GameObject[] myObjects; //array of the targets

    public Rigidbody BallR; //what makes the object thats fired
    public Rigidbody BallL; //what makes the object thats fired

    public float spawned = 15; //for spawning targets
    public float velocity = 50; //speed of object fired
    public float gameTime = 30; // time of the game in seconds
    static public int triggerScore = 0; // start of the triggerScore




    bool fireR = false; //checks if the sphere has been fired
    bool fireL = false; //checks if the sphere has been fired
    // Start is called before the first frame update
    void Start()
    {
        while (spawned > 0)
        {
            int randomIndex = Random.Range(0, myObjects.Length);
            Vector3 randomSpawning = new Vector3(Random.Range(-10,15),5, Random.Range(-10,15));

            Instantiate(myObjects[randomIndex], randomSpawning, Quaternion.Euler(90,0,0));
            spawned--; //adds 15 targets randomly across the plane 
        }
        triggerScore = 0; // sets my score as 0 for the game.
    }

    // Update is called once per frame
    void Update()
    {
        //making the game end using either game time or game Score.
        gameTime -= Time.deltaTime;
        if (gameTime < 0 || triggerScore > 149) //checks if either the time has ran out or the user achieved 150 points = all targets hit
        {
            SceneManager.LoadScene("TargetShootEnd"); //loads the end scene
        }


      

        //triggers linked through oculus documentation to the game.

        float triggerLeft = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger); //getting the Left Trigger
        float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger); // getting the right Trigger
        bool buttonStart = OVRInput.Get(OVRInput.RawButton.Start); //getting the start button

        //makes the start button load the menu
        if(buttonStart == true)
        {
            SceneManager.LoadScene("TargetShootMenu"); // loads the game menu back if start menu is clicked.
        }

        // makes the right trigger button spawn a cloned ball that has a rigidbody so that it can collide with other objects, at the specific location on the right controller, 
        // while also going towards the Z axis at the given velocity.
        if(triggerRight > 0.8f && fireR == false)
        {
            fireR = true;

            Rigidbody clone = Instantiate(BallR, transform.position, transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(new Vector3(0,0,velocity));
            Destroy(clone.gameObject,3); 
        }


        // makes the left trigger button spawn a cloned ball that has a rigidbody so that it can collide with other objects, at the specific location on the left controller, 
        // while also going towards the Z axis at the given velocity.
        if(triggerLeft > 0.8f && fireL == false)
        {
            fireL = true;

            Rigidbody clone = Instantiate(BallL, transform.position, transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(new Vector3(0,0,velocity));
            Destroy(clone.gameObject,3); 
        }

        // making sure it doesnt spam the spawning of the ball, making it seperate clicks per spawn.
        if (fireR == true && triggerRight<0.1f) 
        {
            fireR = false; // this ensures that when the trigger is pressed it doesn't spawn multiple balls
        }

        if (fireL == true && triggerLeft<0.1f) 
        {
            fireL = false; // same as the right function
        }

        // keeps the gui updated
        updateGUI(); 
    }

    

    //keeps a countdown of the game timer and sends it to the GUI
    void updateGUI()
    {
        string buffer = "Time: " + gameTime.ToString("00.0")
        + "\nScore: " + triggerScore;
        gameData.text = buffer; 
    }
}
