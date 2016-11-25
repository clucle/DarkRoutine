using UnityEngine;
using System.Collections;

public class Enem_1 : MonoBehaviour {
    private Rigidbody2D rbody;
    private static float speed = -2f;
    // Use this for initialization


    void Start () {
        //this.gameObject.tag = "En_white";
        rbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        rbody.velocity = new Vector2(rbody.velocity.x, speed);
        this.gameObject.transform.Rotate(new Vector3(0,0,1));
        if (this.gameObject.transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
    public void DestroyPrefab()
    {
        Destroy(this.gameObject);
    }
    public void UpSpeed(float speed_up)
    {
        speed -= speed_up;
        Debug.Log(speed);
    }
    public void InitSpeed()
    {
        if(speed > -10) speed = -2;
    }
}
