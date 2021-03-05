using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float runSpeed = 3f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] int points = 10;
    Rigidbody2D rigidbody;
    Animator animator;
    [SerializeField] int Score = 0;
    bool isCrouch = false;
    BoxCollider2D myBody;
    float sizeY, offsetY;
    ScoreController scoreController;
    bool isAlive = true;
    public AudioSource SoundEffects;
    public GameObject[] Lifes;
    private int Life = 3;
    private Vector2 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myBody = GetComponent<BoxCollider2D>();
        sizeY = myBody.size.y;
        offsetY = myBody.offset.y;
        scoreController = FindObjectOfType<ScoreController>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            return;
        }
        Run();
        Jump();
        Crouch();
        Die();
    }
    private void Run()
    {
        if(isCrouch)
        {
            return;
        }
       
        float speed = CrossPlatformInputManager.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(speed*runSpeed, rigidbody.velocity.y);
        if(rigidbody.velocity.x !=0)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidbody.velocity.x), transform.localScale.y);
        }
        if(speed!=0)
        {
            animator.SetFloat("Speed", 0.5f);
        }
        else
        {
            animator.SetFloat("Speed", 0.2f);
        }
    }
    private void Jump()
    {
        
        if(!myBody.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if(CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void Crouch()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouch = true;
            myBody.size = new Vector2(myBody.size.x, sizeY/2);
            myBody.offset = new Vector2(myBody.offset.x, offsetY/2);
            animator.SetBool("Crouch", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouch = false;
            myBody.size = new Vector2(myBody.size.x, sizeY );
            myBody.offset = new Vector2(myBody.offset.x, offsetY);
            animator.SetBool("Crouch", false);
        }
    }
    public void PickupKey()
    {
        scoreController.increaseScore(points);
    }
    private void Die()
    {
        if(myBody.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            Life--;
            if(Life == 2)
            {
                Destroy(Lifes[0].gameObject);
                transform.position = initialPosition;
            }
            else if (Life == 1)
            {
                Destroy(Lifes[1].gameObject);
                transform.position = initialPosition;
            }
            else if (Life == 0)
            {
                Destroy(Lifes[2].gameObject);
                SoundEffects.clip = FindObjectOfType<SoundManager>().Sounds[2];
                SoundEffects.Play();
                isAlive = false;
                animator.SetTrigger("Die");
                StartCoroutine(RestartScene());
            }
        }
            
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
        
    }


}
