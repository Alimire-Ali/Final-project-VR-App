using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMechanic : MonoBehaviour
{
    [Header("Game Score")]
    public TMP_Text gameData;

    public GameObject[] myObjects;

    public Rigidbody Ball; //what makes the object thats fired

    public float spawned = 15; //for spawning targets
    public float velocity = 50; //speed of object fired
    public float gameTime = 30; // time of the game in seconds
    static public int score = 0; // start of the score




    bool fire = false;
    // Start is called before the first frame update
    void Start()
    {
        while (spawned > 0)
        {
            int randomIndex = Random.Range(0, myObjects.Length);
            Vector3 randomSpawning = new Vector3(Random.Range(-10,15),5, Random.Range(-10,15));

            Instantiate(myObjects[randomIndex], randomSpawning, Quaternion.Euler(90,0,0));
            spawned--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //making the game end using either game time or game score.
        gameTime -= Time.deltaTime;
        if (gameTime < 0 || score > 149)
        {
            SceneManager.LoadScene("TargetShootMenu");
        }


      

        //triggers linked through oculus documentation to the game.

        float triggerLeft = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);
        float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
        bool buttonStart = OVRInput.Get(OVRInput.RawButton.Start);

        //makes the start button load the menu
        if(buttonStart == true)
        {
            SceneManager.LoadScene("TargetShootMenu");
        }

        // makes the right trigger button spawn a cloned ball that has a rigidbody so that it can collide with other objects, at the specific location on the right controller, 
        // while also going towards the Z axis at the given velocity.
        if(triggerRight > 0.8f && fire == false)
        {
            fire = true;

            Rigidbody clone = Instantiate(Ball, transform.position, transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(new Vector3(0,0,velocity));
            Destroy(clone.gameObject,3);


        }


        // making sure it doesnt spam the spawning of the ball, making it seperate clicks per spawn.
        if (fire == true && triggerRight<0.1f) 
        {
            fire = false;
        }

        // keeps the gui updated
        updateGUI();
    }

    

    //keeps a countdown of the game timer and sends it to the GUI
    void updateGUI()
    {
        string buffer = "Time: " + gameTime.ToString("00.0")
        + "\nScore: " + score;
        gameData.text = buffer; 
    }
}
