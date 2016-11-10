using UnityEngine;
using System.Collections;

public class pattern : MonoBehaviour {
    public GameObject whitePrefab = null;
    public GameObject blackPrefab = null;
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
}
