using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * instantiateFog.cs
 * a class to create multiple instances of Fog across a poriton of a cave
 * TW
 */
public class instantiateFog : MonoBehaviour
{
    public GameObject fog; // an asset that covers the screen in a fog



    // Start is called before the first frame update
    void Start() {
        try{
            // creates a new fog object of a set size across the screen
            // This covers a whole section of the cave system
            Instantiate(fog, new Vector2(0, 0), transform.rotation);
            Instantiate(fog, new Vector2(5, -15), transform.rotation);
            Instantiate(fog, new Vector2(5, -30), transform.rotation);
            Instantiate(fog, new Vector2(-20, -35), transform.rotation);
            Instantiate(fog, new Vector2(-20, -20), transform.rotation);
            Instantiate(fog, new Vector2(0, -45), transform.rotation);
            Instantiate(fog, new Vector2(5, -60), transform.rotation);
            Instantiate(fog, new Vector2(35, -50), transform.rotation);
            Instantiate(fog, new Vector2(37, -39), transform.rotation);
            Instantiate(fog, new Vector2(36, -29), transform.rotation);
        }
        catch{
            //code that is needed for coding standards, unused
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
