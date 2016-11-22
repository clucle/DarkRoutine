using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class End : MonoBehaviour {
    public GameObject ui_Lobby;
    public Button Back;
    public void On_Click()
    {
        FadeOutMe();
        soundManager.instance.PlayStart();
        Back.interactable = false;
    }
    public void init()
    {
        Back.interactable = false;
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
        Back.interactable = true;
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
