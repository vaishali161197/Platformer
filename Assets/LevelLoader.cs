using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public AudioSource SoundEffects;
    public string levelName;
    LevelManager levelManager;

    public void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    public void onClick()
    {
        SoundEffects.clip = FindObjectOfType<SoundManager>().Sounds[0];
        SoundEffects.Play();
        LevelStatus levelStatus = levelManager.GetLevelStatus(levelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Can't play this level, till you unlocked it");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(levelName);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(levelName);
                break;
        }

       
    }
    
}
