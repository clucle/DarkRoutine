using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lobby : MonoBehaviour {
    public GameObject ui_Ingame;
    public GameObject player;
    public Button Start_btn;

    private Player Player;
    private ingame inGame;
    private CanvasGroup canvasGroup;
    public void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        inGame = ui_Ingame.gameObject.GetComponent<ingame>();
        Player = player.gameObject.GetComponent<Player>();
    }
    public void Button_Click()
    {
        FadeMe();
        soundManager.instance.PlayStart();
        Start_btn.interactable = false;
    }

    public void init()
    {
        FadeInMe();
        Start_btn.interactable = false;
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
        Start_btn.interactable = true;

    }

    public void FadeMe()
    {
        StartCoroutine(DoFade());
    }
    IEnumerator DoFade()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 2;
            
            yield return null;
        }

        Player.Set_limit_key(false);
        Player.init();
        ui_Ingame.SetActive(true);
        inGame.On_Click();
        
        gameObject.SetActive(false);
    }
}
