using UnityEngine;
using System.Collections;

/*
// Use this for initialization
void Start () {

}

// Update is called once per frame

void Update () {

    if (Input.anyKeyDown)
    {
        Instantiate(whitePrefab, new Vector3(-2f, 5f, 0), Quaternion.identity);
        Instantiate(blackPrefab, new Vector3(2f, 5f, 0), Quaternion.identity);
    }
}
*/

public class pattern : MonoBehaviour {
    public GameObject whitePrefab = null;
    public GameObject blackPrefab = null;

    public void DoPattern1()
    {
        float check_is_black = Random.Range(0.0f, 1.0f);
        bool is_black = (check_is_black < 0.5f) ? true : false;

        float x_transcorm = Random.Range(-1.8f, 1.8f);

        if(is_black) Instantiate(whitePrefab, new Vector3(x_transcorm, 5f, 0), Quaternion.identity);
        else Instantiate(blackPrefab, new Vector3(x_transcorm, 5f, 0), Quaternion.identity);
    }
}

