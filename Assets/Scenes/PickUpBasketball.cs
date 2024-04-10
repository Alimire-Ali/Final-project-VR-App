using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PickUpBasketball : MonoBehaviour
{

    List<Vector3> trackingPos = new List<Vector3>();
    public float velocity = 1000f;

    GameObject parentHand;
    bool pickedUp = false;
    Rigidbody bb;

    public HoopCollision hoopCollision;

    // Start is called before the first frame update
    void Start()
    {
        bb = GetComponent<Rigidbody>();

        hoopCollision = GameObject.FindObjectOfType(typeof(HoopCollision)) as HoopCollision;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp == true)
        {
            bb.useGravity = false;

            transform.position = parentHand.transform.position;
            transform.rotation = parentHand.transform.rotation;

            if (trackingPos.Count > 15)
            {
                trackingPos.RemoveAt(0);
            }
            trackingPos.Add(transform.position);

            float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
            float triggerLeft = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);

            if (triggerRight < 0.1f && triggerLeft < 0.1f)
            {
                pickedUp = false;
                Vector3 direction = trackingPos[trackingPos.Count - 1] - trackingPos[0].normalized;
                bb.AddForce(direction * velocity);
                bb.useGravity = true;
                bb.isKinematic = false;
                GetComponent<Collider>().isTrigger = false;
                Destroy(gameObject,3);
                hoopCollision.BallRespawn();
                Debug.Log("trigger released");
            }
        }
        // updateGUI();
    }


    private void OnTriggerEnter(Collider other)
    {
        float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
        if (other.gameObject.CompareTag("RightHand") && triggerRight > 0.8f)
        {
            pickedUp = true;
            parentHand = other.gameObject;
            Debug.Log("trigger clicked");
        }

        float triggerLeft = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);
        if (other.gameObject.CompareTag("LeftHand") && triggerLeft > 0.8f)
        {
            pickedUp = true;
            parentHand = other.gameObject;
            Debug.Log("trigger clicked");
        }
    }
 }
