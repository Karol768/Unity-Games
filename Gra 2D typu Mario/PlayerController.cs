using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;
    private bool isGrounded;
    private float radius = 0.1f;
    public Transform groundDetector;
    public LayerMask layersToTest;
    Animator anim;
    Rigidbody2D rgdBody;
    bool dirToRight = true;
    public Transform startPoint;
    public AudioClip deathClip;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rgdBody = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y<-6.5f)
        {
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            if(gameObject.transform.position.y<-50.0f)
            {
                RestartPlayer();
            }
            
        }

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Hurt"))
        {
            rgdBody.velocity = Vector2.zero;
            return;
        }

        isGrounded = Physics2D.OverlapCircle(groundDetector.position, radius, layersToTest);
        float horizontalMove = Input.GetAxis("Horizontal");
        rgdBody.velocity = new Vector2 (horizontalMove * playerSpeed, rgdBody.velocity.y);
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rgdBody.AddForce(new Vector2(0f, jumpForce));
            anim.SetTrigger("jump");
        }

        anim.SetFloat ("speed", Mathf.Abs(horizontalMove));

        if(horizontalMove < 0 && dirToRight)
        {
            Flip();
        }

        if(horizontalMove > 0 && !dirToRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        dirToRight = !dirToRight;
        Vector3 playerScale = gameObject.transform.localScale;
        playerScale.x *= -1;
        gameObject.transform.localScale = playerScale;
    }

    void RestartPlayer()
    {
        gameObject.transform.position = startPoint.position;
    }
}
