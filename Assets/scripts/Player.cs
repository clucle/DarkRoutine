using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    // Sprite
    public Sprite Black_back;
    public Sprite White_back;
    public Sprite Black_ch;
    public Sprite White_ch;

    // Character declare
    private Rigidbody2D rbody;
    private Transform tform;
    private float speed;

    //black true white false;
    private bool isBlack;

    // Background and Text
    public GameObject background;
    public Text text_distance;
    public Text text_score;
    public Text best_score;
    public Text text_end;

    //Renderer
    private SpriteRenderer BackRender;
    private SpriteRenderer PlayerRender;

    public GameObject ui_Ingame;
    private ingame ingameover;
    

    private Touch touch;
    private Enem_1 Enem1;

    // gameover -> limit key
    private bool b_isgameover;
    private bool limit_key;

    private Vector3 v;

    // Use this for initialization
    public void init() {
        b_isgameover = false;
    }
    public void Set_limit_key (bool islimit)
    {
        limit_key = islimit;
    }

	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        tform = GetComponent<Transform>();

        PlayerRender = this.gameObject.GetComponent<SpriteRenderer>();
        PlayerRender.sprite = Black_ch;

        BackRender = background.GetComponent<SpriteRenderer>();
        BackRender.sprite = Black_back;

        isBlack = true;

        speed = 3.0f;
        v = transform.position;

        b_isgameover = false;
        limit_key = true;

        ingameover = ui_Ingame.gameObject.GetComponent<ingame>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!limit_key && !b_isgameover) {
            float horizontal = 0;
            if (Application.platform == RuntimePlatform.Android)
            {
                horizontal = Input.acceleration.x * speed;
            }
            else
            {
                horizontal = Input.GetAxis("Horizontal") * speed;
            }
            h_movement(horizontal);

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
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
            v.x = -2.23f;
            tform.transform.position = v;
        }
        if (tform.transform.position.x > 2.23)
        {
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
            BackRender.sprite = White_back;
            PlayerRender.sprite = White_ch;
            text_distance.color = Color.black;
            text_score.color = Color.black;
            best_score.color = Color.black;
            text_end.color = Color.black;
            isBlack = false;
        }
        else
        {
            BackRender.sprite = Black_back;
            PlayerRender.sprite = Black_ch;
            text_distance.color = Color.white;
            text_score.color = Color.white;
            best_score.color = Color.white;
            text_end.color = Color.white;
            isBlack = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!b_isgameover)
        {
            string En_color = "";
            if (isBlack == true) En_color = "En_black";
            else if (isBlack == false) En_color = "En_white";

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
                
                //Destroy(other.gameObject);
                soundManager.instance.PlayHit();
                if (!isBlack) ChangeColor();
                b_isgameover = true;
                ingameover.GameOver();
            }
        }

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (!b_isgameover)
        {
            string En_color = "";
            if (isBlack == true) En_color = "En_black";
            else if (isBlack == false) En_color = "En_white";

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
                
                //Destroy(other.gameObject);
                
                soundManager.instance.PlayHit();
                if (!isBlack) ChangeColor();
                b_isgameover = true;
                ingameover.GameOver();
            }
        }
    }
}
