using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* SoundScript.cs
* Triggers Sound for the main player
* TW
*/
public class SoundScript : MonoBehaviour
{
    // private audio clips to store the sounds of different foosteps
    private AudioClip town;
    private AudioClip wood;
    private AudioClip snow;
    private AudioClip forest;
    private AudioClip grass;
    private AudioClip house;
    private AudioClip rock;
    private AudioClip graveyard;
    private GameObject ground;
    AudioSource MyAudioSource; //Audio Source to apply the sounds to


    // Start is called before the first frame update
    void Start()
    {
        snow = (AudioClip) Resources.Load("PB - Footstep SFX/Footstep SFX/Snow_Jogging");
        wood = (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Gravel_Jogging");
        town = (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Dirt_Jogging");
        forest = (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Gravel_Jogging");
        grass = (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Leaves_Rustling");
        house = (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/NormalWood_Barefeet_Running");
        graveyard = (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Gravel_Jogging");
        rock = (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Gravel_Ice_Shoes_Walking");
        MyAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        // Finds the object named ground and grabs the tag associated with it
        //GameObject ground = GameObject.Find("/Grid/Ground");
        //if (ground == null)
        //{
        //    //If no object named ground try tilemap
        //    ground = GameObject.Find("/Grid/Tilemap");
        //}
   
        foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
        {
            if (obj.tag == "rock" || obj.tag == "snow" || obj.tag == "wood" || obj.tag == "town" || obj.tag == "forest" || obj.tag == "grass" || obj.tag == "house" || obj.tag == "graveyard")
            {
                ground = obj;
                break;
            }
            
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            try
            {
                //On movement, play grass sound if player is on grass
                if (ground.CompareTag("grass"))
                {
                    WalkOnGrass();
                }

                //On movement, play rock sound if player is on rock
                if (ground.CompareTag("rock"))
                {

                    WalkOnRock();
                }
            }
            catch
            {
                Debug.Log("Cant find Ground Tag!");
            }
        }
        else
        {
            //If player is not moving, stop audio
            MyAudioSource.Stop();
        }
    }

    //Set clip to grass and play it from MyAudioSource
    void WalkOnGrass()
    {
        MyAudioSource.clip = grass;
        MyAudioSource.volume = 0.5f;
        if (!MyAudioSource.isPlaying)
        {
            MyAudioSource.Play();
        };
    }
    //Set clip to rock and play it from MyAudioSource
    void WalkOnRock()
    {
        MyAudioSource.clip = rock;
        MyAudioSource.pitch = 1.5f;
        MyAudioSource.volume = 0.5f;
        if (!MyAudioSource.isPlaying)
        {
            MyAudioSource.Play();
        } 
    }
}
