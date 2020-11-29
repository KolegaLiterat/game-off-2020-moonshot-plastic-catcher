using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RecyclerAirlock : MonoBehaviour
{
    public int Points = 0;

    [SerializeField]
    GameObject SpawnContainer;
    [SerializeField]
    Text PointsValue;

    List<GameObject> ListOfSpawnedObjects;

    AudioSource AddPoint;

    private void Start()
    {
        ListOfSpawnedObjects = SpawnContainer.GetComponent<SpawnedObjects>().BottlesOnScene;
        PointsValue.text = " " + Points;
        AddPoint = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string collision_tag = collision.tag;

        if (collision_tag == "Bottle" && collision.GetComponent<Bottle>().isCatched == true)
        {
            ListOfSpawnedObjects.Remove(collision.gameObject);
            Points++;
            PointsValue.text = " " + Points;
            Destroy(collision.gameObject);
            AddPoint.Play();
        }
    }

}
