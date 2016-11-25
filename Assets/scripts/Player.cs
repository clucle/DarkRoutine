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
    public Text best_score;
    public Text text_end;

    public GameObject ui_Ingame;
    private ingame ingameover;
    private bool b_isgameover;

    private bool limit_key;
    private Enem_1 Enem1;
    // Use this for initialization
    public void init() {
        b_isgameover = false;
    }

    
    public void Set_limit_key (bool islimit)
    {
        //Debug.Log(islimit);
        
        limit_key = islimit;
    }

	void Start () {
        // Init ch
        limit_key = true;
        rbody = GetComponent<Rigidbody2D>();
        tform = GetComponent<Transform>();
        speed = 3;
        b_isgameover = false;
        // Init sprite
        isBlack = true;
        background.GetComponent<SpriteRenderer>().sprite = Black_back;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Black_ch;

        ingameover = ui_Ingame.gameObject.GetComponent<ingame>();

    }
	
	// Update is called once per frame
	void Update () {
        if (!limit_key && !b_isgameover) {
            float horizontal = 0;
            if (Application.platform == RuntimePlatform.Android)
            {
                horizontal = Input.acceleration.x * 1.4f;
            }
            else
            {
                horizontal = Input.GetAxis("Horizontal");
            }

            

            h_movement(horizontal);

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        soundManager.instance.PlayChange();
                        ChangeColor();

                        break;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                soundManager.instance.PlayChange();
                ChangeColor();
            }
            
        }
        if (b_isgameover)
        {
            float horizontal = 0;
            h_movement(horizontal);
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
        if (!b_isgameover)
        {
            rbody.velocity = new Vector2(horizontal * speed, rbody.velocity.y);
        }else
        {
            rbody.velocity = new Vector2(0, rbody.velocity.y);
        }
        
    }

    private void ChangeColor()
    {
        if(isBlack == true)
        {
            background.GetComponent<SpriteRenderer>().sprite = White_back;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = White_ch;
            text_distance.color = Color.black;
            text_score.color = Color.black;
            best_score.color = Color.black;
            text_end.color = Color.black;
            isBlack = false;
        }
        else
        {
            background.GetComponent<SpriteRenderer>().sprite = Black_back;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Black_ch;
            text_distance.color = Color.white;
            text_score.color = Color.white;
            best_score.color = Color.white;
            text_end.color = Color.white;
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
            try
            {
                Enem1 = GameObject.FindWithTag("En_white").GetComponent<Enem_1>();
                Enem1.InitSpeed();
            }
            catch
            {
                Enem1 = GameObject.FindWithTag("En_black").GetComponent<Enem_1>();
                Enem1.InitSpeed();
            }

            foreach (GameObject wpf in GameObject.FindGameObjectsWithTag("En_white"))
            {
                Destroy(wpf);
            }
            foreach (GameObject bpf in GameObject.FindGameObjectsWithTag("En_black"))
            {
                Destroy(bpf);
            }
            soundManager.instance.PlayHit();
            if (!isBlack) ChangeColor();
            b_isgameover = true;
            ingameover.GameOver();
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        string En_color = "";
        if (isBlack == true) En_color = "En_black";
        else if (isBlack == false) En_color = "En_white";

        if (other.gameObject.tag != En_color) // diffent with me and collider
        {
            foreach (GameObject wpf in GameObject.FindGameObjectsWithTag("En_white"))
            {
                Destroy(wpf);
            }
            foreach (GameObject bpf in GameObject.FindGameObjectsWithTag("En_black"))
            {
                Destroy(bpf);
            }
            soundManager.instance.PlayHit();
            if (!isBlack) ChangeColor();
            b_isgameover = true;
            ingameover.GameOver();
        }
    }
}
