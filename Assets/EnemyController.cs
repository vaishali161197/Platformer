using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    CapsuleCollider2D Body;
    Rigidbody2D rigidbody;
    Animator animator;
    [SerializeField] float Speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponent<CapsuleCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }
    private void EnemyMove()
    {
        if(transform.localScale.x > 0)
        {
            rigidbody.velocity = new Vector2(Speed, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(-Speed, rigidbody.velocity.y);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rigidbody.velocity.x)),1f);
    }
}
