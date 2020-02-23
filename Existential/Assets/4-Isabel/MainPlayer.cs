using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour{

    string input;
    bool isRL;

    // Start is called before the first frame update
    void Start(){
        
    }
    public void Init(bool isRL){
        isRL = isRightMovement;
        Vector2 pos = Vector2.zero;

        if(isRL){
            input = "PlayerRL";
        } else{
            input = "PlayerUD";
        }
        transform.position = pos;
        transform.name = input;
    }


    // Update is called once per frame
    void Update(){
        float move = input.GetAxis(input) * Time.deltaTime;
        transform.Translate(move * Vector2.up);
        
    }
}
