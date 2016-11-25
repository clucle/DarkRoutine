using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ingame : MonoBehaviour {
    private float game_score;
    private float best_score;

    public GameObject pattern_obj = null;

    public Text text_score;
    public Text text_best_score;
    private float pattern1;
    private float pattern2;
    private float pattern34;
    private float pattern56;
    private pattern spawning;


    public GameObject player;
    private Transform tform;
    public bool isgameover;

    public GameObject ui_End;
    public Text ui_EndText;
    public GameObject ScoreManager;

    private Enem_1 Enem1;
    private float pattern_time;

    void init()
    {
        isgameover = false;
        
        game_score = 0;
        pattern1 = 0.5f; // just random
        pattern2 = 2.4f;
        
        pattern34 = 5.3f;
        pattern56 = 20;
        spawning = pattern_obj.gameObject.GetComponent<pattern>();
        spawning.GameOver(false);
        tform = player.GetComponent<Transform>();
        best_score = ScoreManager.gameObject.GetComponent<scoreManager>().LoadScore();
        pattern_time = 1;
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
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * 1;
            yield return null;
        }

    }

    void Update()
    {
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



                


            }
            if (pattern2 * pattern_time < game_score)
            {
                pattern2 += 2.4f * pattern_time;
                spawning.DoPattern2(0);
            }
            if (pattern34 * pattern_time < game_score)
            {
                pattern34 += 5.3f * pattern_time;
                float check_is_rand = Random.Range(0.0f, 1.0f);
                bool is_rand = (check_is_rand < 0.5f) ? true : false;
                if (is_rand) spawning.DoPattern3();
                else spawning.DoPattern4();
            }
            if (pattern56 * pattern_time < game_score)
            {
                pattern56 += 20 * pattern_time;
                float check_is_rand = Random.Range(0.0f, 1.0f);
                bool is_rand = (check_is_rand < 0.5f) ? true : false;
                if (is_rand) spawning.DoPattern5();
                else spawning.DoPattern6();
                try
                {
                    Enem1 = GameObject.FindWithTag("En_white").GetComponent<Enem_1>();
                    Enem1.UpSpeed(0.2f);
                }
                catch
                {
                    Enem1 = GameObject.FindWithTag("En_black").GetComponent<Enem_1>();
                    Enem1.UpSpeed(0.2f);
                }
                pattern1 *= pattern_time;
                pattern2 *= pattern_time;
                pattern34 *= pattern_time;
                pattern56 *= pattern_time;
                if (pattern_time > 0.5f) pattern_time -= 0.02f;
                pattern1 /= pattern_time;
                pattern2 /= pattern_time;
                pattern34 /= pattern_time;
                pattern56 /= pattern_time;
            }
        }
    }
    public void GameOver()
    {
        isgameover = true;
        spawning.GameOver(true);
        ScoreManager.gameObject.GetComponent<scoreManager>().SaveScore(game_score);
        FadeOutMe();
    }

    public void FadeOutMe()
    {
        StartCoroutine(DoFadeOut());
    }
    IEnumerator DoFadeOut()
    {
        player.gameObject.GetComponent<Player>().Set_limit_key(true);
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            Vector3 v = player.transform.position;
            v.x = (tform.transform.position.x * 95 / 100);
            tform.transform.position = v;

            canvasGroup.alpha -= Time.deltaTime * 1;
            yield return null;
        }

        ui_End.SetActive(true);
        ui_End.gameObject.GetComponent<End>().init();
        soundManager.instance.PlayGameOver();
        ui_EndText.text = game_score.ToString("#0.00");
        gameObject.SetActive(false);
    }

}

