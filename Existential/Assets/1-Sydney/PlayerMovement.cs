using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will move the character forward, side to side
//or backwards depending on the keys WSAD.

//CharacterController needs to be attached to main character
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
  
    float height;
    
    string input;
    public bool isCharacter;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
    }

    public void Init(bool isMainCharacter)
	{
	 	Vector2 pos = Vector2.zero;

		input = "PlayerMovement";

		transform.position = pos;

		transform.name = input;
	}

    // Update is called once per frame
    void Update()
    {
	// move the Character
        float move = Input.GetAxis(input) * Time.deltaTime * speed;
	
	//Restrict Movement
	if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0) 
	{
		move = 0;
	}

	if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0) 
	{
		move = 0;
	}
	transform.Translate (move * Vector2.up);
    }


}

