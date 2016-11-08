using UnityEngine;
using System.Collections;

public class Enem_1 : MonoBehaviour {
    private Rigidbody2D rbody;
	// Use this for initialization
	void Start () {
        //this.gameObject.tag = "En_white";
        rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rbody.velocity = new Vector2(rbody.velocity.x, -2);
    }
}
