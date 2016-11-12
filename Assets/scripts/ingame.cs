using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ingame : MonoBehaviour {
    private float game_score;

    public GameObject pattern_obj = null;

    public Text text_score;
    private float pattern1;
    private int pattern2;
    private int pattern34;
    private int pattern56;
    private pattern spawning;


    void init()
    {
        game_score = 0;
        pattern1 = 0.5f; // just random
        pattern2 = 2;
        
        pattern34 = 5;
        pattern56 = 20;
        spawning = pattern_obj.gameObject.GetComponent<pattern>();
    }

    public void On_Click()
    {
        init();

        

        FadeInMe();
        Debug.Log("Start!");
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

        Debug.Log("End!");
    }

    void Update()
    {
        game_score += Time.deltaTime * 1;
        text_score.text = game_score.ToString("#0.00");
        
        if (pattern1 < game_score)
        {
            pattern1++;
            spawning.DoPattern1();
        }
        if (pattern2 < game_score)
        {
            pattern2 += 2;
            spawning.DoPattern2(0);
        }
        if (pattern34 < game_score)
        {
            pattern34 += 5;
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
        }
    }
}

