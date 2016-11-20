using UnityEngine;
using System.Collections;

/*
// Use this for initialization
void Start () {

}

// Update is called once per frame

void Update () {

    if (Input.anyKeyDown)
    {
        Instantiate(whitePrefab, new Vector3(-2f, 5f, 0), Quaternion.identity);
        Instantiate(blackPrefab, new Vector3(2f, 5f, 0), Quaternion.identity);
    }
}
*/

public class pattern : MonoBehaviour {
    public GameObject whitePrefab = null;
    public GameObject blackPrefab = null;

    private bool isgmaeover;
    public void GameOver(bool isover)
    {
        isgmaeover = isover;
    }

    private IEnumerator coroutine;

    public void DoPattern1()
    {
        // just random spawn
        float check_is_black = Random.Range(0.0f, 1.0f);
        bool is_black = (check_is_black < 0.5f) ? true : false;
        float x_transform = Random.Range(-1.8f, 1.8f);
        SpawnTime(is_black, x_transform, 0);
    }

    public void DoPattern2(float delay)
    {
        // 1 row
        float check_is_black = Random.Range(0.0f, 1.0f);
        bool is_black = (check_is_black < 0.5f) ? true : false;
        for(int index = 0; index < 3; index++)
        {
            SpawnTime(is_black, -1.8f + index * 1.8f, 0);
        }  
    }

    public void DoPattern3()
    {
        float check_is_black = Random.Range(0.0f, 1.0f);
        bool is_black = (check_is_black < 0.5f) ? true : false;
        for (int index = 0; index < 3; index++)
        {
            SpawnTime(is_black, -1.8f + index * 1.8f, index * 0.6f);
        }
    }

    public void DoPattern4()
    {
        float check_is_black = Random.Range(0.0f, 1.0f);
        bool is_black = (check_is_black < 0.5f) ? true : false;
        for (int index = 0; index < 3; index++)
        {
            SpawnTime(is_black, +1.8f + -1f * index * 1.8f, index * 0.6f);
        }
    }
    public void DoPattern5()
    {
        float check_is_black = Random.Range(0.0f, 1.0f);
        bool is_black = (check_is_black < 0.5f) ? true : false;

        float check_is_left = Random.Range(0.0f, 1.0f);
        bool is_left = (check_is_left < 0.5f) ? true : false;

        float x;
        if (is_left) x = -1.8f;
        else x = 1.8f; 
        for (int index = 0; index < 100; index++)
        {
            SpawnTime(is_black, x, index * 0.2f);
        }
    }
    public void DoPattern6()
    {
        float check_is_left = Random.Range(0.0f, 1.0f);
        bool is_left = (check_is_left < 0.5f) ? true : false;

        float x;
        if (is_left) x = -1.8f;
        else x = 1.8f;

        float check_is_black = Random.Range(0.0f, 1.0f);
        bool is_black = (check_is_black < 0.5f) ? true : false;
        for (int index = 0; index < 100; index++)
        {
            SpawnTime(is_black, x, index * 0.2f);
        }
    }
    private void SpawnTime(bool is_black, float x, float delay)
    {
        if (is_black)
        {
            coroutine = SpawnWhite(x, delay);
            StartCoroutine(coroutine);
        }
        else
        {
            coroutine = SpawnBlack(x, delay);
            StartCoroutine(coroutine);
        }
    }
    private IEnumerator SpawnWhite(float x, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //if(pattern_obj.gameObject.GetComponent<ingame>();)
        if(!isgmaeover) Instantiate(whitePrefab, new Vector3(x, 5f, 0), Quaternion.identity);
    }
    private IEnumerator SpawnBlack(float x, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (!isgmaeover) Instantiate(blackPrefab, new Vector3(x, 5f, 0), Quaternion.identity);
    }
    
}

