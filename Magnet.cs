using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// based on https://sharpcoderblog.com/blog/unity-3d-rigidbody-magnet
public class Magnet : MonoBehaviour
{
    [SerializeField]
    float MagnetForce = 45.0f;

    [SerializeField]
    List<Rigidbody2D> CaughtObjects = new List<Rigidbody2D>();

    // Update is called once per frame
    private void FixedUpdate()
    {
        for (int i = 0; i < CaughtObjects.Count; i++)
        {
                CaughtObjects[i].velocity = (transform.position - CaughtObjects[i].transform.position) * MagnetForce * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() && collision.tag == "Bottle")
        {
            Rigidbody2D bottle = collision.GetComponent<Rigidbody2D>();
            collision.GetComponent<Bottle>().isCatched = true;

            if (!CaughtObjects.Contains(bottle))
            {
                CaughtObjects.Add(bottle);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() && collision.tag == "Bottle")
        {
            Rigidbody2D bottle = collision.GetComponent<Rigidbody2D>();
            collision.GetComponent<Bottle>().isCatched = false;

            if (CaughtObjects.Contains(bottle))
            {
                CaughtObjects.Remove(bottle);
            }
        }
    }
}
