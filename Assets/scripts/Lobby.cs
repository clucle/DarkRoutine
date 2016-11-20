using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lobby : MonoBehaviour {
    public GameObject ui_Ingame;
    public GameObject player;
    public Button Start;
    public void Button_Click()
    {
        FadeMe();
        Start.interactable = false;
    }

    public void init()
    {
        FadeInMe();
        Start.interactable = false;
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
        Start.interactable = true;

    }

    public void FadeMe()
    {
        StartCoroutine(DoFade());
    }
    IEnumerator DoFade()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 2;
            
            yield return null;
        }
        yield return null;
        player.gameObject.GetComponent<Player>().Set_limit_key(false);
        player.gameObject.GetComponent<Player>().init();
        ui_Ingame.SetActive(true);
        ui_Ingame.gameObject.GetComponent<ingame>().On_Click();
        

        gameObject.SetActive(false);
    }
}
