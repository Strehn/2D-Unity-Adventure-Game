using UnityEngine;
using System.Collections.Generic;
/*
 * instantiateFog.cs
 * a class to create multiple instances of Fog across a poriton of a cave
 * TW
 */


public sealed class TaeganSingleton: MonoBehaviour {
    private static TaeganSingleton objectToInstaniate;
    public static TaeganSingleton Instance { get { return objectToInstaniate; }}

    private void Start() {
        if(objectToInstaniate != null && objectToInstaniate != this){
            Destroy(this.gameObject);
        }else {
            objectToInstaniate = this;
        }
    }
}

//Iterator Pattern
public class Itterator : MonoBehaviour
{
    static int index = 0;
    static public int first() { return index; } //initialize first variable
    static public int next() { return index++; } //iterate to next 
    static public bool isDone(int max) { return index == max; } //return if iteration is done
}


public class instantiateFog : MonoBehaviour {
    public GameObject fog; // an asset that covers the screen in a fog
    List<int> coordinatesx;
    List<int> coordinatesy;
    private int j;
    // Start is called before the first frame update
    void Start() {
        j = Itterator.first();
        // creates a new fog object of a set size across the screen
         coordinatesx = new List<int>() { 0, 5, 5, -20, -20, 0, 5, 35, 37, 36, 13 };
         coordinatesy = new List<int>() { 0, -15, -30,-35,-20,-45,-60,-50,-39,-29,-41};

        // This covers a whole section of the cave system
        while (!Itterator.isDone(11)) {
            Instantiate(fog, new Vector2(coordinatesx[j], coordinatesy[j]), transform.rotation);
            j = Itterator.next();
        }
    }
}
