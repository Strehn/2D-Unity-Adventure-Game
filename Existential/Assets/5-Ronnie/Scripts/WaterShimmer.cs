using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterShimmer : MonoBehaviour
{
    public SpriteRenderer sparkle;
    private Color opaque, start, middle, end, transpar;
    private int state;
    private float time;
    private bool timer;

    // Start is called before the first frame update
    void Start()
    {
        state = Random.Range(1, 8);
        time = .3f;
        timer = true;
        opaque = new Color(1f, 1f, 1f, 1f);
        start = new Color(1f, 1f, 1f, .75f);
        middle = new Color(1f, 1f, 1f, .5f);
        end = new Color(1f, 1f, 1f, .25f);
        transpar = new Color(1f, 1f, 1f, 0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 1 && Time.time >= time)
        {
            sparkle.GetComponent<SpriteRenderer>().material.color = opaque;
            state = 2;
            time = Time.time + .2f;
        }
        else if (state == 2 && Time.time >= time)
        {
            sparkle.GetComponent<SpriteRenderer>().material.color = start;
            state = 3;
            time = Time.time + .2f;
        }
        else if (state == 3 && Time.time >= time)
        {
            sparkle.GetComponent<SpriteRenderer>().material.color = middle;
            state = 4;
            time = Time.time + .2f;
        }
        else if (state == 4 && Time.time >= time)
        {
            sparkle.GetComponent<SpriteRenderer>().material.color = end;
            state = 5;
            time = Time.time + .2f;
        }
        else if (state == 5 && Time.time >= time)
        {
            sparkle.GetComponent<SpriteRenderer>().material.color = transpar;
            state = 6;
            time = Time.time + .2f;
        }
        else if (state == 6 && Time.time >= time)
        {
            sparkle.GetComponent<SpriteRenderer>().material.color = end;
            state = 7;
            time = Time.time + .2f;
        }
        else if (state == 7 && Time.time >= time)
        {
            sparkle.GetComponent<SpriteRenderer>().material.color = middle;
            state = 8;
            time = Time.time + .2f;
        }
        else if (state == 8 && Time.time >= time)
        {
            sparkle.GetComponent<SpriteRenderer>().material.color = start;
            state = 1;
            time = Time.time + .2f;
        }
    }

   
}
