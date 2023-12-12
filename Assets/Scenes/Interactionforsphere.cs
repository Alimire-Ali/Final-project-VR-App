using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody Ball;
    // public InputActionProperty rightActivate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // float triggerRight = setActive.rightActivate.action.ReadValue.<float>();
        float triggerLeft = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);
        float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);

        if(triggerRight>0.9f)
        {
            Instantiate(Ball,new Vector3(0,0,0), Quaternion.identity);
        }
    }
}
