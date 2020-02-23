using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class npc : MonoBehaviour
{

    public float speed = 2.0f;
    public float boundY = 4f;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;
        if (GameObject.FindGameObjectWithTag("Player").transform.position.y > GameObject.Find("npc2").transform.position.y + 0.2)
        {
           //Do Nothing
        }
        else if (GameObject.FindGameObjectWithTag("Player").transform.position.y < GameObject.Find("npc2").transform.position.y - 0.2)
        {
            //Do Nothing
        }
        else
        {
            checkForInputs();

        }

        if (GameObject.FindGameObjectWithTag("Player").transform.position.y > GameObject.Find("npc2").transform.position.x + 0.2)
        {
            //Do Nothing
        }
        else if (GameObject.FindGameObjectWithTag("Player").transform.position.y < GameObject.Find("npc2").transform.position.x - 0.2)
        {
            //Do Nothing
        }
        else
        {
            checkForInputs();

        }


        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;

        if (Input.GetKey("escape"))

            Application.Quit();
    }


    void checkForInputs()
    {
        if (Input.GetKey(KeyCode.I)){
        //SceneManager.LoadScene("Dialouge");
        //Do Nothing
        }
    }



}
