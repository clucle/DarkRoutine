using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    // Character declare
    private Rigidbody2D rbody;
    private float speed;

    // Sprite
    private bool isBlack;//black true white false;
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
        isBlack = true;
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
        if(isBlack == true)
        {
            background.GetComponent<SpriteRenderer>().sprite = White_back;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = White_ch;
            isBlack = false;
        }
        else
        {
            background.GetComponent<SpriteRenderer>().sprite = Black_back;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Black_ch;
            isBlack = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        string En_color = "";
        if (isBlack == true) En_color = "En_black";
        else if(isBlack == false) En_color = "En_white";
       
        if (other.gameObject.tag != En_color) // diffent with me and collider
        {
            Debug.Log("A");
            ChangeColor();
        }
        
    }

}
