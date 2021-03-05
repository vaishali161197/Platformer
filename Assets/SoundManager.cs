using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource SoundEffects;
    public AudioSource SoundMusic;
    public AudioClip[] Sounds;
    private void Awake()
    {
        int count = FindObjectsOfType<SoundManager>().Length;
        if(count > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       // AudioClip clip = Sounds[1];
        SoundMusic.clip = Sounds[1];
        SoundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
