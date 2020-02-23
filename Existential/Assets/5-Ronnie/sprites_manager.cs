using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprites_manager : MonoBehaviour
{
    public GameObject[] waters;
    public GameObject water;
    // Start is called before the first frame update
    void Start()
    {
        waters = new GameObject[11];
        //bottom level water tiles
        waters[0] = Instantiate(water, new Vector3(-4.5f, -4.5f, 0.0f), transform.rotation) as GameObject;
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

    }

    // Update is called once per frame
    void Update()
    {

    }
}
