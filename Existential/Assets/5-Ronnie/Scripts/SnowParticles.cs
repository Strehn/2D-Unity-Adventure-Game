using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowParticles : MonoBehaviour
{
    public GameObject snow;
    private Rigidbody2D rb;
    private float rand;
    private int poss;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            poss = Random.Range(1, 50);
            if (poss == 1)
            {
                rand = Random.Range(-10f, 200f);
                Instantiate(snow, new Vector2(rand, 5f), transform.rotation);
            }
        }
        if (rb.position.y < 2f)
            Destroy(snow);
    }
}
