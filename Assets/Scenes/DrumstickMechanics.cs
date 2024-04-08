using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumstickMechanics : MonoBehaviour
{

    GameObject startTransformation;
    Transform controller;
    bool pickedUp = false;

    // Start is called before the first frame update
    void Start()
    {
        startTransformation = new GameObject();

        startTransformation.transform.position = transform.position;
        startTransformation.transform.rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp == true)
        {
            transform.position = controller.position;
            transform.rotation = controller.rotation;
        }
        else
        {
            transform.position = startTransformation.transform.position;
            transform.rotation = startTransformation.transform.rotation;
        }

        if (OVRInput.Get(OVRInput.Button.Two))
        {
            pickedUp = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        pickedUp = true;
        controller = other.gameObject.transform;
    }
}
