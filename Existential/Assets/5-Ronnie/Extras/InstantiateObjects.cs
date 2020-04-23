using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour
{
    public GameObject waterSparkle;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(waterSparkle, new Vector2(-9.6f, -7.5f), transform.rotation);
        Instantiate(waterSparkle, new Vector2(-10.0f, -6.4f), transform.rotation);
        Instantiate(waterSparkle, new Vector2(-10.2f, -7.2f), transform.rotation);
        Instantiate(waterSparkle, new Vector2(-10.3f, -6.4f), transform.rotation);
        Instantiate(waterSparkle, new Vector2(-10.0f, -6.4f), transform.rotation);
        Instantiate(waterSparkle, new Vector2(-10.0f, -6.4f), transform.rotation);
        Instantiate(waterSparkle, new Vector2(-11.2f, -5.4f), transform.rotation);
        Instantiate(waterSparkle, new Vector2(-11.3f, -7.7f), transform.rotation);
        Instantiate(waterSparkle, new Vector2(-10.8f, -6.4f), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
