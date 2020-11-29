using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    Rigidbody2D rb;

    public bool isCatched = false;

    float ClampY = 6.0f;
    float ClampX = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        clamp();
        transform.Rotate(new Vector3(0.0f, 0.0f, 0.5f));
    }

    void clamp()
    {
        if (transform.position.y < ClampY * -1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
            rb.velocity = new Vector3(rb.velocity.x, 2.0f);
        }

        if (transform.position.x > ClampX || transform.position.x < ClampX * -1)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
    }
}
