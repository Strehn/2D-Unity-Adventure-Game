using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* SoundScript.cs
* Triggers Dynamic Class Sound for the main player, NPC, and main camera
* TW
*/
public class Sound : MonoBehaviour {
    private AudioClip song; // AudioClip to store the background song  
    private int ActiveSceneIndex; // stores the current active scene index
    public GameObject ground; //Store the gameobject with ground tag set
    public AudioClip currAudio; // Audio 
    public AudioSource MyAudioSource; //stores the player's attached audioSource
    public AudioSource CameraObj; //Stores the Camera Object Audio Source in the scene
    public GameObject[] PlayerObjects; //Stores all Objects with Player Tag
    public IDictionary<string, AudioClip> walkSounds = new Dictionary<string, AudioClip>();
    public IDictionary<int, AudioClip> backgroundMusic = new Dictionary<int, AudioClip>();

    //Start is called first once
    public void Start() {
        //SET PRIVATE VARIABLES
        walkSounds.Add("forest", (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Gravel_Jogging"));
        walkSounds.Add("castle", (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Concrete_Boots_Running"));
        walkSounds.Add("rock", (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Gravel_Ice_Shoes_Walking"));
        walkSounds.Add("grass", (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Leaves_Rustling"));
        walkSounds.Add("graveyard", (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Gravel_Jogging"));
        walkSounds.Add("town", (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Gravel_Jogging"));
        backgroundMusic.Add(1, (AudioClip)Resources.Load("Song#1"));
        backgroundMusic.Add(2, (AudioClip)Resources.Load("Song#2"));
        backgroundMusic.Add(4, (AudioClip)Resources.Load("Song#4"));
        backgroundMusic.Add(5, (AudioClip)Resources.Load("DragonSong#5"));
        backgroundMusic.Add(6, (AudioClip)Resources.Load("Song#6"));


        ActiveSceneIndex = SceneManager.GetActiveScene().buildIndex; // Get Active Scene

        //SET GAME OBJECTS
        GameObject[] MainCam = GameObject.FindGameObjectsWithTag("MainCamera"); // MainCamera Object
        PlayerObjects = GameObject.FindGameObjectsWithTag("Player"); // MainCamera Object

        //get active player's audioSource
        foreach (GameObject obj in PlayerObjects) {
            try {
                MyAudioSource = obj.GetComponent<AudioSource>();
                break;
            }
            catch {
                Debug.Log("Was not able to find main Character");
            }
        }

        //Set the Player Audio Source using the WalkSound Function Static
        MyAudioSource.clip = WalkSound();

        //Grab the active Audio Source component of the Camera in the scene
        foreach (GameObject obj in MainCam) {
            try {
                CameraObj = obj.GetComponent<AudioSource>();
            }
            catch {

            }
        }

        //Set the background script based on the current Scene Index
        if (ActiveSceneIndex == 0) {
            //MAIN SCENE
            song = backgroundMusic[1];
        }
        else if (ActiveSceneIndex == 1) {
            //SAMS SCENE
            song = backgroundMusic[1];
        }
        else if (ActiveSceneIndex == 2) {
            //ISABELS SCENE
            song = backgroundMusic[2];
        }
        else if (ActiveSceneIndex == 3 || ActiveSceneIndex == 8) {
            //SYDNEYS SCENE
            song = backgroundMusic[2];
        }
        else if (ActiveSceneIndex == 4 || ActiveSceneIndex == 7) {
            //TORIS SCENE
            song = backgroundMusic[4];
        }
        else if (ActiveSceneIndex == 5) {
            //TAEGANS SCENE
            song = backgroundMusic[6];
        }
        else if (ActiveSceneIndex == 6 || ActiveSceneIndex == 9) {
            //RONNIES SCENE
            song = backgroundMusic[5];
        }
        else {
            // SET OPENING SONG TO PLAY
            song = backgroundMusic[1];
            //Debug.Log("Couldnt set the background Audio");
        }
        
        CameraObj.clip = song; //Set the background Audio

        if (!CameraObj.isPlaying) //Play the Music if the Audio Source is not playing
        {
            CameraObj.Play();
        };
    }

    // Walk Sound used statically to assign walk sound to NPCS
    public virtual AudioClip WalkSound() {
        AudioClip castle = (AudioClip)Resources.Load("PB - Footstep SFX/Footstep SFX/Concrete_Boots_Running");
        return castle;
    }    
}

// SubClass of Sound, SoundScript Dynamically sets the walk sound of the player depending on the ground tag
public class SoundScript : Sound {

    AudioSource MyAudioSource;
    //Override the current function for walk sound
    public override AudioClip WalkSound () {

        // Loop through all of the gameobjects and assess the tag
        foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject))){
            if (obj.tag == "wood" || obj.tag == "castle" || obj.tag == "rock" || obj.tag == "snow" || obj.tag == "town" || obj.tag == "forest" || obj.tag == "grass" || obj.tag == "graveyard") {
                ground = obj; //if ground tag set, break
                break;
            }
        }
        
        try{
            //Set the currAudio to grass, used in Sam's Level
            if (ground.CompareTag("grass")) {
                currAudio = walkSounds["grass"];
            }

            //Set the currAudio to rock, used in Taegan's Level
            else if (ground.CompareTag("rock")) {
                currAudio = walkSounds["rock"];
            }

            //Set the currAudio to graveyard, used in isabels Scene
            else if (ground.CompareTag("graveyard")) {
                currAudio = walkSounds["graveyard"];
            }
            //Set the currAudio to forest used in Sydney's scene
            else if (ground.CompareTag("forest")) {
                currAudio = walkSounds["forest"];
            }
            //Set the currAudio to castle used in Ronnie's Scene, Tori's Scene
            else if (ground.CompareTag("castle")) {
                currAudio = walkSounds["castle"];
            }
            return currAudio;
                
        }
        catch{ //catches no groundtag set and puts default walk sound
            currAudio = walkSounds["castle"];
            return currAudio;
        }
    }

    //If the player is moving, play the walking sound
    public void Update() {
        //Grab the AudioSource Sound
        
        //get active player's audioSource
        foreach (GameObject obj in PlayerObjects)
        {
            try
            {
                MyAudioSource = obj.GetComponent<AudioSource>();
                break;
            }
            catch
            {
                Debug.Log("Was not able to find main Character");
            }
        }
        MyAudioSource.clip = WalkSound();
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
            //Play the Audio Clip if its not currently playing
            if (!MyAudioSource.isPlaying) {
                MyAudioSource.Play();
            }
        }
        else {
            //If player is not moving, stop audio
            MyAudioSource.Stop();
        }
    }
}