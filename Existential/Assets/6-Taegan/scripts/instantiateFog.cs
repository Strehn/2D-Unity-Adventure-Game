using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateFog : MonoBehaviour
{
    public GameObject fog;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(fog, new Vector2(0, 0), transform.rotation);
        Instantiate(fog, new Vector2(5, -15), transform.rotation);
        Instantiate(fog, new Vector2(5, -30), transform.rotation);
        Instantiate(fog, new Vector2(-20, -35), transform.rotation);
        Instantiate(fog, new Vector2(-20, -20), transform.rotation);
        Instantiate(fog, new Vector2(0, -45), transform.rotation);
        Instantiate(fog, new Vector2(5, -60), transform.rotation);
        Instantiate(fog, new Vector2(35, -50), transform.rotation);
        Instantiate(fog, new Vector2(37, -39), transform.rotation);
        Instantiate(fog, new Vector2(36, -29), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
