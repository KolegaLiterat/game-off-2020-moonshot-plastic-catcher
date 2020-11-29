using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> PlasticBottles = new List<GameObject>();
    public GameObject PlayerObject;
    public GameObject SpawnedObjectContainer;
    

    bool isCoroutineNeeded = true;

    Player PlayerScript;
    SpawnedObjects SpawnedObjectsScript;
    Magnet MagnetScript;
    
    IEnumerator SpawnThrash()
    {
        while (isCoroutineNeeded)
        {
            int seconds = Random.Range(1, 5);

            spawn_bottle();

            yield return new WaitForSeconds(seconds);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerScript = PlayerObject.GetComponent<Player>();
        SpawnedObjectsScript = SpawnedObjectContainer.GetComponent<SpawnedObjects>();

        StartCoroutine(SpawnThrash());

        if (Time.timeScale == 0.0f)
        {
            Time.timeScale = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnedObjectsScript.BottlesOnScene.Count == 10 && isCoroutineNeeded == true)
        {
            isCoroutineNeeded = false;
        }

        if (SpawnedObjectsScript.BottlesOnScene.Count < 10 && isCoroutineNeeded == false)
        {
            spawn_bottle();
        }

    }

    void spawn_bottle()
    {
        int index = Random.Range(0, PlasticBottles.Count);
        int x_position = Random.Range(-8, 8);

        PlasticBottles[index].transform.position = new Vector3(x_position, 6.0f, 0.0f);
        GameObject new_bottle = Instantiate(PlasticBottles[index], PlasticBottles[index].transform.position, PlasticBottles[index].transform.rotation);

        SpawnedObjectsScript.BottlesOnScene.Add(new_bottle);
    
    }
}
