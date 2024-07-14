using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D mybody;
    private float moveForce_x = 1.5f, moveForce_y = 1.5f;
    private PlayerAnimations playerAnim;
    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimations>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h > 0)
        {
            mybody.velocity = new Vector2 (moveForce_x, mybody.velocity.y);
        }
        else if (h < 0)
        {
            mybody.velocity = new Vector2(-moveForce_x, mybody.velocity.y);
        }
        else
        {
            mybody.velocity = new Vector2(0f, mybody.velocity.y);
        }

        if (v > 0)
        {
            mybody.velocity = new Vector2(mybody.velocity.x, moveForce_y);
        }
        else if (v < 0)
        {
            mybody.velocity = new Vector2(mybody.velocity.x, -moveForce_y);
        }
        else
        {
            mybody.velocity = new Vector2(mybody.velocity.x, 0f);
        }


        if(mybody.velocity.y != 0 || mybody.velocity.x != 0)
        {
            playerAnim.PlayerRunAnim(true);
        }
        else if(mybody.velocity == Vector2.zero)
        {
            playerAnim.PlayerRunAnim(false);
        }

        Vector3 tempScale = transform.localScale;

        if(h > 0)
        {
            tempScale.x = -1f;
        }
        else if (h < 0)
        {
            tempScale.x = 1f;
        }

        transform.localScale = tempScale;

    }
}
