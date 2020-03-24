using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.UpArrow;
    public KeyCode moveDown = KeyCode.DownArrow;
    public KeyCode moveLeft = KeyCode.LeftArrow;
    public KeyCode moveRight = KeyCode.RightArrow;
    public CharacterController controller;
    private AudioClip town;
    private AudioClip wood;
    private AudioClip snow;
    private AudioClip forest;
    private AudioClip grass;
    private AudioClip house;
    private AudioClip rock;
    private AudioClip graveyard;

    AudioSource MyAudioSource;
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
        GameObject ground = GameObject.Find("/Grid/Ground");
        if (ground == null)
        {
            ground = GameObject.Find("/Grid/Tilemap");
        }
        if (Input.GetKey(moveUp) || Input.GetKey(moveDown) || Input.GetKey(moveLeft) || Input.GetKey(moveRight))
        {
            if (ground.CompareTag("grass"))
            {
                WalkOnGrass();
            }
            if (ground.CompareTag("rock"))
            {
                //Debug.Log("rock");
                WalkOnRock();
            }
      
           
            //elseif (hit.gameObject.tag == "Wood" && step == true && controller.velocity.magnitude > 7)
            //{
            //    // RunOnWood();
            //}
            //else if (hit.gameObject.tag == "Grass" && step == true && controller.velocity.magnitude < 7)
            //{
            //    // WalkOnGrass();
            //}
            //else if (hit.gameObject.tag == "Grass" && step == true && controller.velocity.magnitude > 7)
            //{
            //    //RunOnGrass();
            //}
            //else if (hit.gameObject.tag == "Snow" && step == true && controller.velocity.magnitude < 7)
            //{
            //    // WalkOnSnow();
            //}
            //else if (hit.gameObject.tag == "Snow" && step == true && controller.velocity.magnitude > 7)
            //{
            //    //RunOnSnow();
            //}
            //else if (hit.gameObject.tag == "Forest" && step == true && controller.velocity.magnitude < 7)
            //{
            //    // WalkOnForest();
            //}
            //else if (hit.gameObject.tag == "Forest" && step == true && controller.velocity.magnitude > 7)
            //{
            //    //RunOnForest();
            //}
            //else if (hit.gameObject.tag == "Town" && step == true && controller.velocity.magnitude < 7)
            //{
            //    // WalkOnTown();
            //}
            //else if (hit.gameObject.tag == "Town" && step == true && controller.velocity.magnitude > 7)
            //{
            //    RunOnTown();
            //}
        }
        else
        {
            //Debug.Log("audio stop");
            MyAudioSource.Stop();
        }
    }

    void WalkOnTown()
    {
        MyAudioSource.clip = town;
        MyAudioSource.pitch = 1f;
        MyAudioSource.volume = 0.5f;
        if (!MyAudioSource.isPlaying)
        {
            MyAudioSource.Play();
        }

    }

    void WalkOnGrass()
    {
        MyAudioSource.clip = grass;
        MyAudioSource.volume = 0.5f;
        if (!MyAudioSource.isPlaying)
        {
            MyAudioSource.Play();
        };
    }
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
    void WalkOnSnow()
    {
        MyAudioSource.clip = snow;
        MyAudioSource.pitch = 1f;
        MyAudioSource.volume = 0.5f;
        if (!MyAudioSource.isPlaying)
        {
            MyAudioSource.Play();
        }

    }

    void WalkOnForest()
    {
        MyAudioSource.clip = forest;
        MyAudioSource.pitch = 1f;
        MyAudioSource.volume = 0.5f;
        if (!MyAudioSource.isPlaying)
        {
            MyAudioSource.Play();
        }

    }
    void WalkOnHouse()
    {
        MyAudioSource.clip = house;
        MyAudioSource.pitch = 1f;
        MyAudioSource.volume = 0.5f;
        if (!MyAudioSource.isPlaying)
        {
            MyAudioSource.Play();
        }

    }
    void WalkOnGraveyard()
    {
        MyAudioSource.clip = graveyard;
        MyAudioSource.pitch = 1f;
        MyAudioSource.volume = 0.5f;
        if (!MyAudioSource.isPlaying)
        {
            MyAudioSource.Play();
        }

    }

  

}
