// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;

// public class ShootonActivation : MonoBehaviour
// {

//     public GameObject Ball;
//     public Transform spawnPoint;
//     public float speed = 20;
//     // Start is called before the first frame update
//     void Start()
//     {
//         XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
//         grabbable.activated.AddListener(Fire);
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     public void Fire(ActivateEventArgs arg)
//     {
//         GameObject spawnedBall = Instantiate(Ball);
//         spawnedBall.transform.position = spawnPoint.position;
//         spawnedBall.GetComponent<RigidBody>().velocity = spawnPoint.forward * speed;
//     }
// }
