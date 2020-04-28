using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wellTransport : MonoBehaviour
{
    GameObject[] SnowVariant;
    GameObject Snow;
    public GameObject MainCharacter;
    Rigidbody2D rb;
    Transform transform;
    void OnTriggerStay2D(Collider2D collision)
    {
        SnowVariant = GameObject.FindGameObjectsWithTag("snowParticle"); // Snow Object
        Snow = GameObject.Find("Grid");
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("transporting Player!!!");
            if (MainCharacter.GetComponent<Rigidbody2D>().position.x > 0)
            {
                MainCharacter.GetComponent<Rigidbody2D>().position = new Vector2(-72, -77);
                Snow.GetComponent<Particles>().enabled = true; // enable snow particle effect
            }
            else
            {
                MainCharacter.GetComponent<Rigidbody2D>().position = new Vector2(183.5f, -55);
                Snow.GetComponent<Particles>().enabled = false; // disable snow particle effect
                int numOfObject = Snow.GetComponent<Particles>().numOfObjects;
                foreach (GameObject snowPiece in SnowVariant)
                {
                    Destroy(snowPiece);
                }

            }

        }
    }

    void Start(){

         rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
         transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void FixedUpdate(){
        //--------- TRANSPORT SCRIPTS -----------
        // if the player is in field, transfer him to the next area

        // from ice cave to fog cave
        if (rb.position.x >= 144 && rb.position.x <= 148 && rb.position.y <= -7) {
            transform.position = new Vector2(46, -28);
        }

        // from fog cave to ice cave
        else if (rb.position.x >= 46 && rb.position.x <= 48 && rb.position.y >= -26) {
            transform.position = new Vector2(147, -6.3f);
        }

        // from fog cave to entrance
        else if (rb.position.x >= 4.1f && rb.position.x <= 4.8f && rb.position.y >= 2) {
            transform.position = new Vector2(-74, -82);
            //Snow.GetComponent<Particles>().numOfObjects = 100;
            //Snow.GetComponent<Particles>().spawnSpeed = 4;
            //Snow.GetComponent<Particles>().enabled = true; // enable snow particle effect
            foreach (GameObject snowPiece in SnowVariant) {
                snowPiece.GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        // from entrance to fog cave
        else if (rb.position.x >= -74.5f && rb.position.x <= -74.3f && rb.position.y <= -85) {
            transform.position = new Vector2(4.4f, 1);
            //Snow.GetComponent<Particles>().enabled = false; // disable snow particle effect
            //Snow.GetComponent<Particles>().numOfObjects = 1;
            //Snow.GetComponent<Particles>().spawnSpeed = 0;
            foreach (GameObject snowPiece in SnowVariant) {
                snowPiece.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        // from ice cave to end
        else if (rb.position.x >= 234 && rb.position.x <= 235 && rb.position.y >= -25) {
            transform.position = new Vector2(69, -240);
            //Snow.GetComponent<Particles>().numOfObjects = 100;
            //Snow.GetComponent<Particles>().spawnSpeed = 4;
            //Snow.GetComponent<Particles>().enabled = true; // enable snow particle effect
            foreach (GameObject snowPiece in SnowVariant) {
                snowPiece.GetComponent<SpriteRenderer>().enabled = true;
            }

        }

        // from end to ice cave
        else if (rb.position.x >= 68 && rb.position.x <= 71f && rb.position.y <= -242) {
            transform.position = new Vector2(234.5f,-26);
            //Snow.GetComponent<Particles>().enabled = false; // disable snow particle effect
            //Snow.GetComponent<Particles>().spawnSpeed = 0;
            //Snow.GetComponent<Particles>().numOfObjects = 1;
            foreach (GameObject snowPiece in SnowVariant) {
                snowPiece.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        // from end to End Level
        else if (rb.position.x >= 69 && rb.position.x <= 71f && rb.position.y >= -204) {
            SceneManager.LoadScene(6); //Load Ronnies Start Scene
        }
    }     
}