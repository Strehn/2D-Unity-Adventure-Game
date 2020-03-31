using UnityEngine;

public class SoundScriptObjects : MonoBehaviour
{
    public Vector3 dist;
    public Transform other;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        GameObject Mainplayer = GameObject.Find("MainCharacter");
        //Vector3.Distance(Mainplayer, gameObject.name);
        Debug.Log(string.Format("Distance between {0} and {1} is: {2}", Mainplayer, gameObject, dist));
    }
}
