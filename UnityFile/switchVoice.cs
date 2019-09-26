using UnityEngine;
using System.Collections;

public class switchVoice : MonoBehaviour
{
    public static switchVoice _instance;
    public AudioClip[] _clips;
    public AudioClip backgroundMusic;
    private AudioSource _audioSource;
    void Awake()
    {
        this.GetComponent<AudioSource> ().clip = backgroundMusic;
        this.GetComponent<AudioSource>().Play();
    }

    public void PlayMusic(int i)
    {   

        
        this.GetComponent<AudioSource>().clip = _clips[i];
        this.GetComponent<AudioSource>().Play();
    }
    void Update()
    {
        int ran = Random.Range(0, 2);
        this.GetComponent<AudioSource>().clip = _clips[ran];
        this.GetComponent<AudioSource>().Play();

    }
}
