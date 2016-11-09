using UnityEngine;
using System.Collections;

public class pattern : MonoBehaviour {
    public GameObject whitePrefab = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            Instantiate(whitePrefab);
        }
	}
}
