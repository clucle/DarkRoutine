using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class End : MonoBehaviour {
    public GameObject ui_Lobby;
    public Button Back;

    private CanvasGroup canvasGroup;
    private Lobby Lobby;

    public void Start()
    {
        Lobby = ui_Lobby.gameObject.GetComponent<Lobby>();
    }

    public void On_Click()
    {
        FadeOutMe();
        soundManager.instance.PlayStart();
        Back.interactable = false;
    }
    public void init()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
        Back.interactable = false;
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
        Back.interactable = true;
    }

    public void FadeOutMe()
    {
        StartCoroutine(DoFadeOut());
    }
    IEnumerator DoFadeOut()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 1;
            yield return null;
        }

        ui_Lobby.SetActive(true);
        Lobby.init();
        
        gameObject.SetActive(false);
    }

}

