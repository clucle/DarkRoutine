using UnityEngine;
using System.Collections;

public class Enem_1 : MonoBehaviour {
    private Rigidbody2D rbody;
    private static float speed = -3f;

    private Transform tform;
    private Vector3 myrotate;
    private Vector3 myspeed;

    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        tform = GetComponent<Transform>();
        myrotate = new Vector3(0, 0, 1);
        myspeed = new Vector2(rbody.velocity.x, speed);
    }
	
	void Update () {
        rbody.velocity = myspeed;
        tform.Rotate(myrotate);
        if (tform.position.y < -5)
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
        if(speed < -2.0) speed += speed_up;
    }
    public void InitSpeed()
    {
        speed = -3;
    }
}
