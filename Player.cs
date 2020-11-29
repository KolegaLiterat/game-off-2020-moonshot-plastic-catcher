using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health;
    public bool isPlayerAlive = true;
    public GameObject GlowObject;

    [SerializeField]
    GameObject SpawnContainer;
    [SerializeField]
    Text HealthValue;
    [SerializeField]
    float MoveSpeed = 20.0f;
    [SerializeField]
    float RotateSpeed = 40.0f;

    List<GameObject> ListOfSpawnedObjects;

    float ClampY = 6.0f;
    float ClampX = 10.5f;
    float VelocityLimit = 3.0f;

    Magnet MagnetScript;
    AudioSource HitSound;

    private void Start()
    {
        MagnetScript = GlowObject.GetComponent<Magnet>();
        ListOfSpawnedObjects = SpawnContainer.GetComponent<SpawnedObjects>().BottlesOnScene;
        HealthValue.text = " " + Health;
        HitSound = GetComponent<AudioSource>(); 
    }

    void FixedUpdate()
    {
        move_player();
        clamp();
        move_magnet_glow();
        limit_velocity();
    }

    private void Update()
    {
        stop_player();
        check_player_health();
    }

    void move_player() 
    {
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * RotateSpeed * Time.deltaTime);

        GetComponent<Rigidbody2D>().AddForce(transform.up * MoveSpeed * Input.GetAxis("Vertical"));
    }

    void clamp()
    {
        if (transform.position.y > ClampY || transform.position.y < ClampY * -1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }

        if (transform.position.x > ClampX || transform.position.x < ClampX * -1)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string collision_tag = collision.tag;

        if (collision_tag == "Bottle")
        {
            ListOfSpawnedObjects.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            Health--;
            HealthValue.text = " " + Health;
            HitSound.Play();
        }
    }

    void move_magnet_glow()
    {
        Vector3 new_position = new Vector3(transform.position.x, transform.position.y, 0);

        MagnetScript.transform.position = new_position;
    }

    void limit_velocity()
    {
        if (GetComponent<Rigidbody2D>().velocity.x > VelocityLimit)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(VelocityLimit, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (GetComponent<Rigidbody2D>().velocity.x < VelocityLimit * -1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(VelocityLimit * -1, GetComponent<Rigidbody2D>().velocity.y);
        }


        if (GetComponent<Rigidbody2D>().velocity.y > VelocityLimit)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, VelocityLimit);
        }
        else if (GetComponent<Rigidbody2D>().velocity.y < VelocityLimit * -1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, VelocityLimit * -1);
        }
    }

    void stop_player()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
    
    void check_player_health()
    {
        if (Health <= 0)
        {
            Time.timeScale = 0f;
            isPlayerAlive = false;
        }
    }

}
