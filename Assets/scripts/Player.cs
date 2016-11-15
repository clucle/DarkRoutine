using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
    // Character declare
    private Rigidbody2D rbody;
    private Transform tform;
    private float speed;

    // Sprite
    private bool isBlack;//black true white false;
    public Sprite Black_back;
    public Sprite White_back;
    public Sprite Black_ch;
    public Sprite White_ch;

    public GameObject background;

    public Text text_distance;
    public Text text_score;

    private bool limit_key;

	// Use this for initialization
    public void Set_limit_key (bool islimit)
    {
        limit_key = islimit;
    }

	void Start () {
        // Init ch
        limit_key = true;
        rbody = GetComponent<Rigidbody2D>();
        tform = GetComponent<Transform>();
        speed = 3;

        // Init sprite
        isBlack = true;
        background.GetComponent<SpriteRenderer>().sprite = Black_back;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Black_ch;

    }
	
	// Update is called once per frame
	void Update () {
        if (!limit_key) {
            float horizontal = Input.GetAxis("Horizontal");
            h_movement(horizontal);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeColor();
            }
        }
    }

    private void h_movement(float horizontal)
    {
        if (tform.transform.position.x < -2.23)
        {
            Vector3 v = transform.position;
            v.x = -2.23f;
            tform.transform.position = v;
        }
        if (tform.transform.position.x > 2.23)
        {
            Vector3 v = transform.position;
            v.x = 2.23f;
            tform.transform.position = v;
        }
        rbody.velocity = new Vector2(horizontal * speed, rbody.velocity.y);
    }

    private void ChangeColor()
    {
        if(isBlack == true)
        {
            background.GetComponent<SpriteRenderer>().sprite = White_back;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = White_ch;
            text_distance.color = Color.black;
            text_score.color = Color.black;
            isBlack = false;
        }
        else
        {
            background.GetComponent<SpriteRenderer>().sprite = Black_back;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Black_ch;
            text_distance.color = Color.white;
            text_score.color = Color.white;
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
            foreach(GameObject wpf in GameObject.FindGameObjectsWithTag("En_white"))
            {
                Destroy(wpf);
            }
            foreach (GameObject bpf in GameObject.FindGameObjectsWithTag("En_black"))
            {
                Destroy(bpf);
            }

            //Debug.Log("A");
            //ChangeColor();

            //foreach(GameObject Enem in pre)
        }
        
    }

}
