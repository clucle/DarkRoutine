using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ingame : MonoBehaviour {
    public GameObject pattern_obj = null;
    public Text text_score;
    public Text text_best_score;
    public GameObject player;
    public GameObject ui_End;
    public Text ui_EndText;
    public GameObject ScoreManager;


    private float game_score;
    private float best_score;

    private float pattern1;
    private float pattern2;
    private float pattern34;
    private float pattern56;

    private float pattern_time;
    
    private bool isgameover;

    private Enem_1 Enem1;
    private Enem_1 Enem2;

    private Transform tform;
    private pattern spawning;
    private scoreManager score_manager;

    private CanvasGroup canvasGroup;
    private End End;

    void Start()
    {
        tform = player.GetComponent<Transform>();
        spawning = pattern_obj.gameObject.GetComponent<pattern>();
        End = ui_End.gameObject.GetComponent<End>();
        best_score = score_manager.LoadScore();

    }
    void init()
    {
        game_score = 0;

        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
        if (score_manager == null) score_manager = ScoreManager.gameObject.GetComponent<scoreManager>();

        best_score = score_manager.LoadScore();

        pattern1 = 0.5f; // just random
        pattern2 = 2.4f;
        pattern34 = 5.3f;
        pattern56 = 20;

        pattern_time = 1;
        isgameover = false;
    }

    public void On_Click()
    {
        init();
        FadeInMe();
        
    }
    public void FadeInMe()
    {
        StartCoroutine(DoFadeIn());
    }
    IEnumerator DoFadeIn()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * 1;
            yield return null;
        }
        

    }
    void Update()
    {
        if (game_score == 0) spawning.GameStart();
        if (!isgameover)
        {
            game_score += Time.deltaTime * 1;
            text_score.text = game_score.ToString("#0.00");

            if(best_score > game_score)
            {
                text_best_score.text = "BEST : " + best_score.ToString("#0.00");
            }else
            {
                text_best_score.text = "BEST : " + game_score.ToString("#0.00");
            }
            

            if (pattern1 * pattern_time < game_score)
            {
                pattern1+= pattern_time;
                spawning.DoPattern1();

                pattern1 *= pattern_time;
                pattern2 *= pattern_time;
                pattern34 *= pattern_time;
                if (pattern_time > 0.7f) pattern_time -= 0.005f;
                pattern1 /= pattern_time;
                pattern2 /= pattern_time;
                pattern34 /= pattern_time;
            }
            if (pattern2 * pattern_time < game_score)
            {
                pattern2 += 2.4f * pattern_time;
                spawning.DoPattern2(0);
            }
            if (pattern34 * pattern_time < game_score)
            {
                pattern34 += 4.9f * pattern_time;
                float check_is_rand = Random.Range(0.0f, 1.0f);
                bool is_rand = (check_is_rand < 0.5f) ? true : false;
                if (is_rand) spawning.DoPattern3();
                else spawning.DoPattern4();
            }
            if (pattern56 < game_score)
            {
                pattern56 += 20;
                float check_is_rand = Random.Range(0.0f, 1.0f);
                bool is_rand = (check_is_rand < 0.5f) ? true : false;
                if (is_rand) spawning.DoPattern5();
                else spawning.DoPattern6();
                try
                {
                    Enem1 = GameObject.FindWithTag("En_white").GetComponent<Enem_1>();
                    Enem1.UpSpeed(0.3f);
                }
                catch
                {
                    Enem2 = GameObject.FindWithTag("En_black").GetComponent<Enem_1>();
                    Enem2.UpSpeed(0.3f);
                }
            }
        }
    }
    public void GameOver()
    {
        isgameover = true;
        spawning.GameOver(true);
        score_manager.SaveScore(game_score);
        FadeOutMe();
    }

    public void FadeOutMe()
    {
        StartCoroutine(DoFadeOut());
    }
    IEnumerator DoFadeOut()
    {
        player.gameObject.GetComponent<Player>().Set_limit_key(true);
        while (canvasGroup.alpha > 0)
        {
            Vector3 v = player.transform.position;
            v.x = (tform.transform.position.x * 95 / 100);
            tform.transform.position = v;

            canvasGroup.alpha -= Time.deltaTime * 1;
            yield return null;
        }

        ui_End.SetActive(true);
        End.init();
        soundManager.instance.PlayGameOver();
        ui_EndText.text = game_score.ToString("#0.00");
        gameObject.SetActive(false);
    }

}

