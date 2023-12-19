using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class Interactionforsphere : MonoBehaviour
{
    public Rigidbody Ball;
    bool fire = false;
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

        if(triggerRight>0.9f && fire == false)
        {
            fire = true;
            Instantiate(Ball,new Vector3(Random.Range(-3,3),Random.Range(1,4),Random.Range(-3,3)), Quaternion.identity);
        }
        if (fire == true && triggerRight<0.1f) 
        {
            fire = false;
        }
    }
}
