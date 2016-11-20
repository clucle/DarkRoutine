using UnityEngine;
using System.Collections;

public class End : MonoBehaviour {
    public GameObject ui_Lobby;
    public void On_Click()
    {
        FadeOutMe();
    }
    public void init()
    {
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

    public void FadeOutMe()
    {
        StartCoroutine(DoFadeOut());
    }
    IEnumerator DoFadeOut()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 1;
            yield return null;
        }

        ui_Lobby.SetActive(true);
        ui_Lobby.gameObject.GetComponent<Lobby>().init();
        

        gameObject.SetActive(false);
    }

}
