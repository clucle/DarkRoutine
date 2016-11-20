using UnityEngine;
using System.Collections;

public class scoreManager : MonoBehaviour {
    public float score;
    public GameObject EndMsg;
    void start()
    {

    }

	public float LoadScore () {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.GetFloat("scorePrefs");
        score = PlayerPrefs.GetFloat("scorePrefs");
        return score;
	}
	public void SaveScore (float game_score) {
        if(game_score > score)
        {
            PlayerPrefs.SetFloat("scorePrefs", game_score);
        }
       
	}
    //if(Application.platform == RuntimePlatform.Android)
    uint exitCount = 0;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            
            exitCount++;
            
            if (!IsInvoking("disableDoubleClick"))
            {
                EndMsg.SetActive(true);
                FadeIn();
                
                Invoke("disableDoubleClick", 0.3f);
            }
                
        }
        if (exitCount == 2)
        {
            CancelInvoke("disableDoubleClick");
            Application.Quit();
        }
    }

    void disableDoubleClick()
    {
        FadeOut();
        exitCount = 0;
    }


    public void FadeIn()
    {
        StartCoroutine(DoFadeIn());
    }
    IEnumerator DoFadeIn()
    {
        CanvasGroup canvasGroup = EndMsg.GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * 4;
            yield return null;
        }
    }

    public void FadeOut()
    {
        StartCoroutine(DoFadeOut());
    }
    IEnumerator DoFadeOut()
    {
        CanvasGroup canvasGroup = EndMsg.GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 4;
            yield return null;
        }
        EndMsg.SetActive(false);
    }


}

