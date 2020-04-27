/*********************
 * Ronnie Keating - Snsow Particle
 * This is the script that goes on to the particle prefab.
 * It relocates and creates the speed of the particle based on the camera.

 * Documentation for Particle Prefab
 * A simple, yet very nice looking particle falling effect for any of your game's needs.
 *
 * This prefab will come loaded with:
 * -A simple particle prefab
 * -Scripts to manipulate the features
 *
 * Prefab Features:
 *  -The ability to change the fall speed (no need to work with gravity and increased velocity)
 *  -Change the color of the particle! This will work with any color typing.
 *  -Multiple colors of particles
 *  -Change the number of objects spawned
 *  -Particles reload based on the camera position. No need to worry about
 *   particle going out of the scope of your user!
 *
 * Tech Specs:
 *  -Unity 2019
 *  -Organized C# scripts for easy changes
 *
 * Refund Policy:
 *  -This asset is free to use, so there is no refund policy
 *
 * Other Notes:
 * -Please mention us in all uses of this asset with @ Studio BlueBox
 * -Email us at studio@bluebox.com for futher questions
 ********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleReload : MonoBehaviour {
    private GameObject obj; //this is the actual snow/confetti prefab
    private Rigidbody2D rigidbody; //to change the speed of the particle
    public float speed; //actual value of speed, set by user in the editor
    // Start is called before the first frame update
    void Start() {
        obj = this.gameObject; //initialize what object we are talking about
        //since it is applied to a particle prefab, this object is it
        rigidbody = GetComponent<Rigidbody2D>(); //get rigidbody component to apply velocity
        rigidbody.velocity = new Vector2(0, speed); //set speed
    }

    // Update is called once per frame
    void Update() {
        //I originally destroyed objects at a certain point, so thats why I check for null
        //However, it was easier to work with everyone's level if I just simply relocated 
        //the particle rather than destroyed it. Like when it goes out of camera view, which
        //it does here
        if (obj != null) {
            //if less than the left side of the camera, move to the right side
            if (obj.transform.position.x < Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x)
                obj.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x, obj.transform.position.y);
            //if greater than the right side of the camera, move to the left side
            else if (obj.transform.position.x > Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x)
                obj.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, obj.transform.position.y);
        }
        if(obj != null) {
            //if less than the bottom of the screen, move to the top
            //this was originally the case of destroying objects, however, it makes more sense
            //to relocated rather than destroy and immediately reinstantiated the same thing over
            //and over again
            if (obj.transform.position.y < Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y)
                obj.transform.position = new Vector2(obj.transform.position.x, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            //if greater than the top of the screen, move to the bottom
            else if (obj.transform.position.y > Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y)
                obj.transform.position = new Vector2(obj.transform.position.x, Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y);
        }
    }
}
