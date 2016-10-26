using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    // Character declare
    private Rigidbody2D rbody;
    private float speed;

    // Sprite
    private bool is_black;//black true white false;
    public Sprite Black_back;
    public Sprite White_back;
    public Sprite Black_ch;
    public Sprite White_ch;

    public GameObject background;


	// Use this for initialization
	void Start () {
        // Init ch
        rbody = GetComponent<Rigidbody2D>();
        speed = 3;

        // Init sprite
        is_black = true;
        background.GetComponent<SpriteRenderer>().sprite = Black_back;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Black_ch;

    }
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        h_movement(horizontal);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColor();
        }
	}

    private void h_movement(float horizontal)
    {
        rbody.velocity = new Vector2(horizontal * speed, rbody.velocity.y);
    }

    private void ChangeColor()
    {
        if(is_black == true)
        {
            background.GetComponent<SpriteRenderer>().sprite = White_back;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = White_ch;
            is_black = false;
        }
        else
        {
            background.GetComponent<SpriteRenderer>().sprite = Black_back;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Black_ch;
            is_black = true;
        }
    }
}
