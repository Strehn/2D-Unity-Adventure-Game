/* Ronnie Keating
 * Instantiate every object and animation script
 * Studio BlueBox
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprites_manager : MonoBehaviour {
    //water game objects, create an array of water objects
    public GameObject[] waters;
    public GameObject water;

    //border objects
    public GameObject RightX;
    public GameObject LeftX;
    public GameObject TopY;
    public GameObject BottomY;

    //water sprites
    public Sprite water1;
    public Sprite water2;

    //determine time to swap out sprites
    private float time;
    private bool timer;

    // Start is called before the first frame update
    void Start() {
        time = Time.time + 1f;
        timer = false;
        waters = new GameObject[11];
        //bottom level water tiles
        waters[0] = Instantiate(water, new Vector3(-4.5f, -4.5f, 0.0f), transform.rotation);
        waters[1] = Instantiate(water, new Vector3(-4.1f, -4.5f, 0.0f), transform.rotation);
        waters[2] = Instantiate(water, new Vector3(-3.7f, -4.5f, 0.0f), transform.rotation);
        waters[3] = Instantiate(water, new Vector3(-3.3f, -4.5f, 0.0f), transform.rotation);
        waters[4] = Instantiate(water, new Vector3(-2.9f, -4.5f, 0.0f), transform.rotation);

        //Second level water tiles
        waters[5] = Instantiate(water, new Vector3(-4.5f, -4.1f, 0.0f), transform.rotation);
        waters[6] = Instantiate(water, new Vector3(-4.1f, -4.1f, 0.0f), transform.rotation);
        waters[7] = Instantiate(water, new Vector3(-3.7f, -4.1f, 0.0f), transform.rotation);
        waters[8] = Instantiate(water, new Vector3(-3.3f, -4.1f, 0.0f), transform.rotation);

        //Top level water tiles
        waters[9] = Instantiate(water, new Vector3(-4.5f, -3.7f, 0.0f), transform.rotation);
        waters[10] = Instantiate(water, new Vector3(-4.1f, -3.7f, 0.0f), transform.rotation);

        Instantiate(RightX);
        Instantiate(LeftX);
        Instantiate(TopY);
        Instantiate(BottomY);

    }

    // Update is called once per frame
    void Update() {
        if(!timer) {
            for(int i = 0; i < 11; i++) {
                this.waters[i].GetComponent<SpriteRenderer>().sprite = water2;
            }
            if(Time.time >= time)
            {
                timer = true;
                time += 1f;
            }
        }
        else {
            for (int i = 0; i < 11; i++) {
                this.waters[i].GetComponent<SpriteRenderer>().sprite = water1;
            }
            if(Time.time >= time)
            {
                timer = false;
                time += 1f;
            }
        }
        
    }
}
