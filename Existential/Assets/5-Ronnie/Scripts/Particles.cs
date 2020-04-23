using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour {
    [SerializeField] public int numOfObjects; // change this variable to make more or less objects spawn
    public GameObject obj;
    public GameObject[] objs; // Snow, leaves, ash, confetti
    private float rand;
    [SerializeField] public float spawnSpeed;
    private int j;
    Snow c1;
    [SerializeField] public int typeOfParticle;

    // Start is called before the first frame update
    void Start() {
        j = RonnieIterate.first();
        //RonnieIterate.first();
        objs = new GameObject[numOfObjects];
        if(typeOfParticle == 1)
            c1 = new Snow();
        else if(typeOfParticle == 2)
            c1 = new Confetti();
    }

    // Update is called once per frame
    void Update() {
        if(c1.isSpawn(numOfObjects, spawnSpeed)) {
            rand = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            objs[j] = Instantiate(obj, new Vector2(rand, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y), transform.rotation);
            c1.changeColor(objs[j]);
            j = RonnieIterate.next();
        }
    }
}
