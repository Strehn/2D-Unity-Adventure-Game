using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowParticles : MonoBehaviour {
    [SerializeField] public int numOfObjects; // change this variable to make more or less objects spawn
    public GameObject obj;
    public GameObject[] objs; // Snow, leaves, ash
    private float rand;
    private float poss;
    [SerializeField] public float spawnSpeed;
    [SerializeField] public float bottomOfLevel;
    [SerializeField] public float topOfLevel;
    private int j;
    private bool[] isAlive;

    // Start is called before the first frame update
    void Start() {
        //spawnSpeed = 5f;       //decrease this value to increase speed, I know, doesnt make sense
        //numOfObjects = 200;     //increase to make more particle objects
        //bottomOfLevel = -3f;
        isAlive = new bool[numOfObjects];
        j = 0;
        objs = new GameObject[numOfObjects];
        for (int i = 0; i < numOfObjects; i++)
            isAlive[i] = false;
    }

    // Update is called once per frame
    void Update() {
        for(int i = 0; i < numOfObjects; i++) {
            if (isAlive[i] == false)
                j = i;
        }
        poss = Random.Range(1f, spawnSpeed);
        if (poss <= 2f && isAlive[j] == false) {
            rand = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            objs[j] = Instantiate(obj, new Vector2(rand, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y + topOfLevel), transform.rotation);
            isAlive[j] = true;
        }
        
        for(int i = 0; i < numOfObjects; i++) {
            /*if(objs[i] != null)
            {
                if (objs[i].transform.position.y < bottomOfLevel)
                {
                    Destroy(objs[i]);
                    isAlive[i] = false;
                }

                if (objs[i].transform.position.x < Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x)
                    objs[i].transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x, objs[i].transform.position.y);
                else if (objs[i].transform.position.x > Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x)
                    objs[i].transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, objs[i].transform.position.y);
            }*/
            if (objs[i] == null)
                isAlive[i] = false;
        }
        
    }
}
