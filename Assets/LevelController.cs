using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    BoxCollider2D door;
    LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<BoxCollider2D>();
        levelManager = FindObjectOfType<LevelManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(door.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            Scene NextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
            levelManager.SetLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);
            levelManager.SetLevelStatus(NextScene.name, LevelStatus.Unlocked);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }

}
