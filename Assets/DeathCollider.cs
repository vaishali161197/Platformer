using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathCollider : MonoBehaviour
{
    BoxCollider2D deathCollider;
    // Start is called before the first frame update
    void Start()
    {
        deathCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(deathCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
