//David Floyd
//repsonsible for controlling the players movement
//help from this yt tutorial - https://www.youtube.com/watch?v=XtQMytORBmM&t=838s



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //set params
    [SerializeField]private float speed;
    [SerializeField] private float jumpHeight;
    private Rigidbody2D body;
    private bool grounded = true;
    private LogicManagerScript logic;
    private bool playerIsAlive = true;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //connecting this object with logic
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsAlive)
        {
            //move left right
            float horizontalInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            //flip the charicter
            if (horizontalInput > 0.01f)
            {
                transform.localScale = new Vector3(3, 3, 3);
            }
            else if (horizontalInput < -0.01f)
            {
                transform.localScale = new Vector3(-3, 3, 3);
            }

            //jump
            if (Input.GetKey(KeyCode.UpArrow) && grounded)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        grounded = false;
    }

    //make sure the player cant fly. needs to be updated to work better with platforms
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("Calling GameOver");
            logic.gameOver();
            playerIsAlive = false;
        }
    }

}
