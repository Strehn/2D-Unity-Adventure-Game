using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class backgroundMusic : MonoBehaviour
{
    AudioSource MyAudioSource; //Audio Source to apply the sounds to
    private AudioClip song;
    // Start is called before the first frame update
    void Start()
    {
        MyAudioSource = GetComponent<AudioSource>();
        int y = SceneManager.GetActiveScene().buildIndex;
        if (y == 0)
        {
            song = (AudioClip)Resources.Load("Song#1");
        }
        else if (y == 1)
        {
            song = (AudioClip)Resources.Load("Song#1");
        }
        else if (y == 2)
        {
            song = (AudioClip)Resources.Load("Song#2");
        }
        else if (y == 3)
        {
            song = (AudioClip)Resources.Load("Song#2");
        }
        else if (y == 4 || y == 7)
        {
            song = (AudioClip)Resources.Load("Song#4");
        }
        else if (y == 5)
        {
            song = (AudioClip)Resources.Load("Song#6");
        }
        else if (y == 6)
        {
            song = (AudioClip)Resources.Load("DragonSong#5");
        }
        StartCoroutine(playMusic());
    }

    IEnumerator playMusic()
    {
        Debug.Log("Playing Song");
        MyAudioSource.clip = song;
        if(MyAudioSource.clip == null){
            Debug.Log("Situation");
        }
        float x = 0;
        float currentVolume = MyAudioSource.volume;
        MyAudioSource.Play();
        while (x <= currentVolume){
            MyAudioSource.volume = x;
            x += 0.25f;
            yield return new WaitForSeconds(1);
        }
        
    }
}