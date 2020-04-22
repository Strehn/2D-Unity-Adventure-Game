using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleReload : MonoBehaviour {
    private GameObject obj;
    private Rigidbody2D rigidbody;
    public float bottomOfLevel;
    public float speed;
    // Start is called before the first frame update
    void Start() {
        obj = this.gameObject;
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(0, speed);
        //bottomOfLevel = Camera.main.ScreenToWorldPoint(new Vector2(0,0).y);
    }

    // Update is called once per frame
    void Update() {
        /*if (obj.transform.position.y < bottomOfLevel)
            Destroy(obj);*/
        if (obj != null) {
            if (obj.transform.position.x < Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x)
                obj.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x, obj.transform.position.y);
            else if (obj.transform.position.x > Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x)
                obj.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, obj.transform.position.y);
        }
        if(obj != null) {
            if (obj.transform.position.y < Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y) {
                obj.transform.position = new Vector2(obj.transform.position.x, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                //rigidbody.velocity = new Vector2(0, -10);
            }
            else if (obj.transform.position.y > Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y)
                obj.transform.position = new Vector2(obj.transform.position.x, Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y);
        }
    }
}
