using UnityEngine;
using System.Collections.Generic;
/*
 * instantiateFog.cs
 * a class to create multiple instances of Fog across a poriton of a cave
 * TW
 */

/*
* Fog PREFAB DOCUMENTATION
  Many games have a need for a camera overlay feature that that adds atmosphere to the game.
* Purpose 
 In many Unity projects, a fog overlay adds atmosphere to an area. This provides a quick and easy way to get started.
* Features 
- Attached to the Grid will spawn object given x and y coordinates within the game 
- Easy to use, Plug n play 
- Open Source code
* Usage 
- Import prefab into Assets/ under Prefabs/ folder
- Prefab can be found in this project under Assets/6-Taegan/Assets/Resources/Prefabs/
- Add instantiateFog.cs script to your grid object and pass in x and y coordinates.
* 
*/

/*
* TaeganCanvasNew PREFAB DOCUMENTATION
 Many tests involve instantiating a playable area to test the game.
* Purpose 
In many Unity projects, a test involves instantiating a playable area. This provides a quick and easy way to get started.
* Features 
- Creates an instantiation of a grid to be used to test the player and its controls within the fog instantiation test and the player movement on ice test
* Usage 
- Import prefab into Assets/ under Prefabs/ folder
- Prefab can be found in this project under Assets/6-Taegan/Assets/Resources/Prefabs/
- Instantiate the prefab, or drag-and-drop it into your scene
* 
*/

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
