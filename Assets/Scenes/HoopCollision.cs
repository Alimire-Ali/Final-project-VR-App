using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HoopCollision : MonoBehaviour
{
    public float bBX = 0;
    public float bBY = 0;
    public float bBZ = 0;


    [Header("Game Score")]
    public TMP_Text gameData;
    public float gameTime = 30; // time of the game in seconds
    static public int hoopScore = 0; // start of the score

    public GameObject Basketball;

    public GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        hoopScore = 0;

    }

    // Update is called once per frame
    void Update()
    {
        gameTime-= Time.deltaTime;
        if(gameTime < 0)
        {
            SceneManager.LoadScene("HoopShootEnd");
        }

        bool buttonStart = OVRInput.Get(OVRInput.RawButton.Start);

        //makes the start button load the menu
        if(buttonStart == true)
        {
            SceneManager.LoadScene("HoopShootMenu");
        }

        updateGUI();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject clone = Instantiate(particles, transform.position, transform.rotation);
        Destroy(collision.gameObject);
        hoopScore += 10;
    }

    public void BallRespawn()
    {
        Vector3 basketballPos = new Vector3(bBX,bBY,bBZ);
        Instantiate(Basketball, basketballPos, Quaternion.identity);
        
    }

    void updateGUI()
    {
        string buffer = "Time: " + gameTime.ToString("00.0")
        + "\nScore: " + hoopScore;
        gameData.text = buffer; 
    }
}
