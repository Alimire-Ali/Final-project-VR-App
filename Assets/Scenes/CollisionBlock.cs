using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBlock : MonoBehaviour
{
        public float maxHeight =  3.0f; //the max height
        public float velocity =  1.0f; // the velocity
        float startHeight = 0; // the beginning height

        public GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        startHeight = transform.position.y; // this makes the targets y position 0
        maxHeight = maxHeight + startHeight; // this adds the max height to the start height.
        velocity -= Random.Range(-0.5f,0.5f); // this makes a random range between -0.5 and 0.5 as the speed as it moves.
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.y -= velocity * Time.deltaTime;

        if (temp.y < startHeight || temp.y > maxHeight) // this checks if the object reaches the max height or below its start height.
        {
            velocity *= -1; // swaps the velocity
        }
        transform.position = temp; // resets the position
    }
    private void OnCollisionEnter(Collision collision) // a collision of the sphere and target
    {
        GameObject clone = Instantiate(particles, transform.position, transform.rotation); // on collision it spawns the particles at the collision position
        Destroy(clone.gameObject,3); // destroys the particles in 3 seconds

        Destroy(gameObject); // gets rid of the sphere
        Destroy(collision.gameObject); // also gets rid of the target
        GameMechanic.triggerScore += 10; // increases score.
    }
}
