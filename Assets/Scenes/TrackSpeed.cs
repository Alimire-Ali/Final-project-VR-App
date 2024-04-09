using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpeed : MonoBehaviour
{

    private Vector3 lastPos;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called on the physics update. dependant on fps
    void FixedUpdate()
    {
        speed = (((transform.position - lastPos).magnitude) / Time.deltaTime);
        lastPos = transform.position;
    }
}
