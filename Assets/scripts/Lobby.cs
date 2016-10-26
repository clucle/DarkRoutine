using UnityEngine;
using System.Collections;

public class Lobby : MonoBehaviour {
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
        Debug.Log("End!");
    }
}
