using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowParticles : MonoBehaviour
{
    public GameObject snow;
    private float rand;
    private int poss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 28; i++)
        {
            poss = Random.Range(1, 15);
            if (poss == 1)
            {
                rand = Random.Range(-12f, 12f);
                Instantiate(snow, new Vector2(rand, 25), transform.rotation);
            }
        }
    }
}
