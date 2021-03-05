using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    CapsuleCollider2D key;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        key = GetComponent<CapsuleCollider2D>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(key.IsTouchingLayers(LayerMask.GetMask("Player")))
        {

            Destroy(gameObject);
            playerController.PickupKey();
        }
    }
}
