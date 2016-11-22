using UnityEngine;
using System.Collections;

public class soundManager : MonoBehaviour {
    public AudioClip soundBack;
    public AudioClip soundStart;
    public AudioClip soundChange;
    public AudioClip soundGameOver;
    // Use this for initialization
    AudioSource asource;

    public static soundManager instance;

    void Awake()
    {
        if (soundManager.instance == null)
            soundManager.instance = this;
    }
	void Start () {
        asource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void PlayStart()
    {
        asource.PlayOneShot(soundStart);
    }
    public void PlayChange()
    {
        asource.PlayOneShot(soundChange);
        
    }
    public void PlayGameOver()
    {
        asource.PlayOneShot(soundGameOver);
    }
}

