using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollUp : MonoBehaviour
{
    // Start is called before the first frame update
    float positiony;
    float positionx;
    // Update is called once per frame
    void Update()
    {
        positiony = this.GetComponent<RectTransform>().position.y;
        positionx = this.GetComponent<RectTransform>().position.x;
        this.GetComponent<RectTransform>().position = new Vector2(positionx, positiony + 1f);
        if (positiony > 2000)
        {
            SceneManager.LoadScene(0);
        }
    }
}
