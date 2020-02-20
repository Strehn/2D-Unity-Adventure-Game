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
    public AudioClip[] town;
    public AudioClip[] wood;
    public AudioClip[] snow;
    public AudioClip[] forest;
    public AudioClip[] grass;
    private bool step = true;
    float audioStepLengthWalk = 0.45f;
    float audioStepLengthRun = 0.25f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveUp) || Input.GetKey(moveDown) || Input.GetKey(moveLeft) || Input.GetKey(moveRight))
        {
            if (hit.gameObject.tag == "Wood" && step == true && controller.velocity.magnitude < 7)
            {
                WalkOnWood();
            }
            else if (hit.gameObject.tag == "Wood" && step == true && controller.velocity.magnitude > 7)
            {
                RunOnWood();
            }
            else if (hit.gameObject.tag == "Grass" && step == true && controller.velocity.magnitude < 7)
            {
                WalkOnGrass();
            }
            else if (hit.gameObject.tag == "Grass" && step == true && controller.velocity.magnitude > 7)
            {
                RunOnGrass();
            }
            else if (hit.gameObject.tag == "Snow" && step == true && controller.velocity.magnitude < 7)
            {
                WalkOnSnow();
            }
            else if (hit.gameObject.tag == "Snow" && step == true && controller.velocity.magnitude > 7)
            {
                RunOnSnow();
            }
            else if (hit.gameObject.tag == "Forest" && step == true && controller.velocity.magnitude < 7)
            {
                WalkOnForest();
            }
            else if (hit.gameObject.tag == "Forest" && step == true && controller.velocity.magnitude > 7)
            {
                RunOnForest();
            }
            else if (hit.gameObject.tag == "Town" && step == true && controller.velocity.magnitude < 7)
            {
                WalkOnTown();
            }
            else if (hit.gameObject.tag == "Town" && step == true && controller.velocity.magnitude > 7)
            {
                RunOnTown();
            }
        }
    }

    void WalkOnTown()
    {
        GetComponent<AudioSource>().clip = concrete[Random.Range(0, concrete.Length)];
        GetComponent<AudioSource>().volume = 0.1f;
        GetComponent<AudioSource>().Play();
        StartCoroutine(WaitForFootSteps(audioStepLengthWalk));
    }

    void RunOnTown()
    {
        GetComponent<AudioSource>().clip = concrete[Random.Range(0, concrete.Length)];
        GetComponent<AudioSource>().volume = 0.1f;
        GetComponent<AudioSource>().Play();
        StartCoroutine(WaitForFootSteps(audioStepLengthWalk));
    }

}

