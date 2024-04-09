using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBlock : MonoBehaviour
{
        public float maxHeight =  3.0f;
        public float velocity =  1.0f;
        float startHeight = 0;

        public GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        startHeight = transform.position.y;
        maxHeight = maxHeight + startHeight;
        velocity -= Random.Range(-0.5f,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.y -= velocity * Time.deltaTime;

        if (temp.y < startHeight || temp.y > maxHeight)
        {
            velocity *= -1;
        }
        transform.position = temp;
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject clone = Instantiate(particles, transform.position, transform.rotation);
        Destroy(clone.gameObject,3);

        Destroy(gameObject);
        Destroy(collision.gameObject);
        GameMechanic.triggerScore += 10;
    }
}
