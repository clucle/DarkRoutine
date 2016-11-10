using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ingame : MonoBehaviour {
    private float game_score;

    public GameObject pattern_obj = null;

    public Text text_score;
    private int pattern1;

    void init()
    {
        pattern1 = 1; // just random
        game_score = 0;
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
            pattern_obj.gameObject.GetComponent<pattern>().DoPattern1();
        }
    }
}
