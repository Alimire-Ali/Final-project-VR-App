using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PickUpBasketball : MonoBehaviour
{

    List<Vector3> trackingPos = new List<Vector3>(); //list of vector 3d's 
    public float velocity = 1000f; 

    GameObject parentHand; 
    bool pickedUp = false;
    Rigidbody bb;

    public HoopCollision hoopCollision; // the script where the ball respawn function is in.

    // Start is called before the first frame update
    void Start()
    {
        bb = GetComponent<Rigidbody>(); // makes the basketball a rigidbody

        hoopCollision = GameObject.FindObjectOfType(typeof(HoopCollision)) as HoopCollision; //this calls it.
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp == true)
        {
            bb.useGravity = false;

            transform.position = parentHand.transform.position; // if picked up it makes the objects position and rotation tied to the controller
            transform.rotation = parentHand.transform.rotation;

            if (trackingPos.Count > 15)
            {
                trackingPos.RemoveAt(0);
            }
            trackingPos.Add(transform.position); // this tracks the last 15 frames of the ball/controllers positions

            float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
            float triggerLeft = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);

            if (triggerRight < 0.1f && triggerLeft < 0.1f)
            {
                pickedUp = false;
                Vector3 direction = trackingPos[trackingPos.Count - 1] - trackingPos[0].normalized; // this adds a direction using the opposite of the tracked positions.
                bb.AddForce(direction * velocity); //multiplied by the velocity that is set
                bb.useGravity = true; //self explanitory, it adds gravity
                bb.isKinematic = false; // removes its kinematisim
                GetComponent<Collider>().isTrigger = false; // self explanitory aswell. turns off the trigger.
                Destroy(gameObject,3);
                hoopCollision.BallRespawn();
                Debug.Log("trigger released");
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
        if (other.gameObject.CompareTag("RightHand") && triggerRight > 0.8f)
        {
            pickedUp = true;
            parentHand = other.gameObject;
            Debug.Log("trigger clicked"); // links the basketball to the controller when the trigger is held
        }

        float triggerLeft = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);
        if (other.gameObject.CompareTag("LeftHand") && triggerLeft > 0.8f)
        {
            pickedUp = true;
            parentHand = other.gameObject;
            Debug.Log("trigger clicked"); // links the basketball to the controller when the trigger is held
        }
    }
 }
