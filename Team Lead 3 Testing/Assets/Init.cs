using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    Rigidbody rb;
    Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(.1f, 0, .2f);
        tf = GetComponent<Transform>();
        tf.position = new Vector3(tf.position.x+UnityEngine.Random.Range(-10f, 10f), tf.position.y + UnityEngine.Random.Range(0f, 10f), tf.position.z + UnityEngine.Random.Range(-10f, 10f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
