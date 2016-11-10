using UnityEngine;
using System.Collections;

public class Lobby : MonoBehaviour {
    public GameObject ui_Ingame;
    public GameObject player;

    public void Button_Click()
    {
        FadeMe();
        Debug.Log("Start!");
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
        canvasGroup.interactable = false;
        yield return null;

        
        ui_Ingame.SetActive(true);
        ui_Ingame.gameObject.GetComponent<ingame>().On_Click();
        player.gameObject.GetComponent<Player>().Set_limit_key(false);

        Debug.Log("End!");
    }
}
