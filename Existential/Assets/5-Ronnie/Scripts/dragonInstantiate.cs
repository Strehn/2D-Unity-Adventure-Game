using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class dragonInstantiate : MonoBehaviour
{
    private GameObject Dragon1;
    private GameObject Dragon2;
    public GameObject Dragon;
    // Start is called before the first frame update
    void Start()
    {
        Dragon1 = Instantiate(Dragon, new Vector2(5.5f, 2), transform.rotation);
        //Dragon2 = Instantiate(Dragon, new Vector2(4.5f, -3), transform.rotation); //check for singleton implementation
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}