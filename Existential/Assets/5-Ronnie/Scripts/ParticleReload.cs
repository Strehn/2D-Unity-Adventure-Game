using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleReload : MonoBehaviour {
    private GameObject obj;
    public float bottomOfLevel;
    // Start is called before the first frame update
    void Start() {
        obj = this.gameObject;
        bottomOfLevel = -3f;
    }

    // Update is called once per frame
    void Update() {
        if (obj.transform.position.y < bottomOfLevel)
            Destroy(obj);
        if (obj != null) {
            if (obj.transform.position.x < Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x)
                obj.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x, obj.transform.position.y);
            else if (obj.transform.position.x > Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x)
                obj.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, obj.transform.position.y);
        }
    }
}
