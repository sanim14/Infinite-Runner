using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    SpriteRenderer spriteRenderer;
    //bool up;
    bool left;
    bool right;
    float speed = 5f;
    float jumpForce = 10f;
    Rigidbody2D rb;
    [SerializeField] GameObject largeBrick;
    [SerializeField] GameObject smallBrick;
    [SerializeField] GameObject mediumBrick;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            animator.SetBool("jump", true);
            rb.velocity = (new Vector2(rb.velocity.x, jumpForce));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
            animator.SetBool("run", true);
            spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
            animator.SetBool("run", true);
            spriteRenderer.flipX = false;
        }



        if (Input.GetKeyUp(KeyCode.W))
        {
            //up = false;
            animator.SetBool("jump", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
            animator.SetBool("run", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
            animator.SetBool("run", false);
        }

        if (!Input.anyKey && !IsGrounded())
        {
            animator.SetBool("fall", true);
        }
        else
        {
            animator.SetBool("fall", false);
        }
    }

    private void FixedUpdate()
    {
        float horizontal = 0f;
        if (left)
            horizontal -= speed;
        if (right)
            horizontal += speed;

        rb.velocity = new Vector2(horizontal, rb.velocity.y);
    }

    public bool IsGrounded()
    {
        bool isGrounded = false;

        Vector2 castFrom = new Vector2(transform.position.x, transform.position.y - GetComponent<SpriteRenderer>().bounds.size.y / 2 - .01f);
        RaycastHit2D hit = Physics2D.Raycast(castFrom, Vector2.down, .1f);
        Debug.DrawRay(castFrom, (Vector2.down * .1f), Color.yellow, 2f, true);

        if (hit.transform != null && hit.transform.tag == "Ground")
        {
            isGrounded = true;
        }

        return isGrounded;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("gameOver"))
        {
            transform.position = new Vector2(-7.29f, -1.78f);
            Manager manager = FindObjectOfType<Manager>();
            manager.Reset();
            left = false;
            right = false;
            animator.SetBool("jump", false);
            animator.SetBool("run", false);
            animator.SetBool("fall", false);

            platforms[] platforms = FindObjectsOfType<platforms>();
            foreach (platforms platform in platforms)
            {
                Destroy(platform.gameObject);
            }


            Instantiate(smallBrick, new Vector2(1.214453f, -0.1863253f), transform.rotation);

            Instantiate(mediumBrick, new Vector2(-7.37f, -2.96f), transform.rotation);

            Instantiate(largeBrick, new Vector2(-4.34f, -2.96f), transform.rotation);
        }
    }
}
