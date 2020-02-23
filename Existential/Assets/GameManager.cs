using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Sydney
    public static Vector2 bottomLeft;
    public static Vector2 topRight;
    
    // Start is called before the first frame update
    void Start()
    {
	//Sydney
        // Convert screen's pixel coordinate into game's coordinate 
       bottomLeft = Camera.main.ScreenToWorldPoint (new Vector2(0,0));
       topRight = Camera.main.ScreenToWorldPoint (new Vector2(Screen.width, Screen.height));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
