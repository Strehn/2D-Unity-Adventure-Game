/* Written by Isabel Hinkle
 * followed tutorial: https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/
 * to implement the singleton pattern and instantiate one candle in scene
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsabelPattern : MonoBehaviour{
    public GameObject Candle;

    public void Start(){
        Instantiate(Candle);  // instantiate the candle once
    }

}

public sealed class ExecuteSingleton: MonoBehaviour{
    private static ExecuteSingleton instance = new ExecuteSingleton();

    public static ExecuteSingleton Instance { 
        get { 
            return instance; 
        }
    }

    private void Start() {
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this.gameObject);
        }
    }
}
