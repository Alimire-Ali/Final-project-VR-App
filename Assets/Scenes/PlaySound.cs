using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySound : MonoBehaviour
{
    private AudioSource source;
    public bool playOnbuttonPress = false;
    public string buttonR;
    public string buttonL;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(playOnbuttonPress)
        {
            CheckButtonPress(); // checks if the given button is pressed
        }

        bool buttonStart = OVRInput.Get(OVRInput.RawButton.Start); 

        //makes the start button load the menu
        if(buttonStart == true)
        {
            SceneManager.LoadScene("Menu"); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DrumStickHead"){
            source.volume = other.gameObject.GetComponent<TrackSpeed>().speed; // uses the trackspeed script to see what the speed of the stick was going before hitting the drum collider
            // tunes the volume based off it. 
            ActivateSound(); // plays sound once drumstick head collides with the drum collider
        }
    }

    private void ActivateSound()
    {
        source.Play(); // plays the sound
        source.pitch = Random.Range(0.8f,1.2f); // gives a random pitch to add more realism
    }

    void CheckButtonPress()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A)) ActivateSound(); 
        if (OVRInput.GetDown(OVRInput.RawButton.X)) ActivateSound(); 
        //get down waits for the trigger to reset before becoming available again. Raw button specifically targets the specific key
    }
}
