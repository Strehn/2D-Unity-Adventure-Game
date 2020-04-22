using UnityEngine;
using UnityEngine.SceneManagement;

/*
* SoundScript.cs
* Triggers Sound for the main player
* TW
*/
public class SoundScript : MonoBehaviour {
    // private audio clips to store the sounds of different foosteps
    private AudioClip town;
    private AudioClip wood;
    private AudioClip snow;
    private AudioClip forest;
    private AudioClip grass;
    private AudioClip house;
    private AudioClip rock;
    private AudioClip graveyard;
    private AudioClip castle;
    private GameObject ground;


    AudioSource MyAudioSource; //Audio Source to apply the sounds to

    // Start is called before the first frame update
    void Start()
    {
        snow = (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Snow_Jogging");
        wood = (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/NormalWood_Boots_Running");
        town = (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Dirt_Jogging");
        forest = (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Gravel_Jogging");
        grass = (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Leaves_Rustling");
        house = (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/NormalWood_Barefeet_Running");
        graveyard = (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Gravel_Jogging");
        castle = (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Concrete_Boots_Running");
        rock = (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Gravel_Ice_Shoes_Walking");
        MyAudioSource = GetComponent<AudioSource>();
        foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
        {
            if (obj.tag == "wood" || obj.tag == "castle" || obj.tag == "rock" || obj.tag == "snow" || obj.tag == "town" || obj.tag == "forest" || obj.tag == "grass" || obj.tag == "graveyard")
            {
                ground = obj;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
            try {
                //On movement, play grass sound if player is on grass
                if (ground.CompareTag("grass")) {
                    MyAudioSource.clip = grass;
                }

                //On movement, play rock sound if player is on rock
                else if (ground.CompareTag("rock")) {
                    MyAudioSource.clip = rock;
                }
                //On movement, play snow sound if player is on rock
                else if (ground.CompareTag("snow"))
                {
                    MyAudioSource.clip = snow;
                }
                //On movement, play grave Yard sound if player is on isabels Scene
                else if (ground.CompareTag("graveyard"))
                {
                    MyAudioSource.clip = graveyard;
                }
                //On movement, play forest sound if player is on Sidneys Level
                else if (ground.CompareTag("forest"))
                {
                    MyAudioSource.clip = forest;
                }
                //On movement, play forest sound if player is on Sidneys Level
                else if (ground.CompareTag("castle"))
                {
                    MyAudioSource.clip = castle;
                }
                //On movement, play forest sound if player is on Sidneys Level
                else if (ground.CompareTag("wood"))
                {
                    MyAudioSource.clip = wood;
                }
            }
            catch {
                Debug.Log("Cant find Ground Sound!");
            }
            if (!MyAudioSource.isPlaying)
            {
                MyAudioSource.Play();
            };
        }
        else {
            //If player is not moving, stop audio
            MyAudioSource.Stop();
        }
    }
}
