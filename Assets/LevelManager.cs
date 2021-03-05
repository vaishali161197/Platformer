using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private void Awake()
    {
        int Count = FindObjectsOfType<LevelManager>().Length; // no.of times this script created
        if(Count > 1)
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
        if(GetLevelStatus("Level 1") == LevelStatus.Locked)
        {
            SetLevelStatus("Level 1", LevelStatus.Unlocked);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetLevelStatus(string Level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(Level, (int) levelStatus);
    }

    public LevelStatus GetLevelStatus(string Level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(Level, 0);
        return levelStatus;
    }
}
