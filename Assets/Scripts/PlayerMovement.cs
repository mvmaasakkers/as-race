using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    
    public Rigidbody2D rb;
    public Animator animator;
    public int score = 0;

    public bool verticalMovementEnabled = false;

    public Text scoreText;
    Vector2 movement;

    public void IncreaseScore()
    {
        score += 1;
    }

    void Update()
    {
        scoreText.text = score.ToString();

        movement.x = Input.GetAxisRaw("Horizontal");
        if (verticalMovementEnabled)
        {
            movement.y = Input.GetAxisRaw("Vertical");
        }

        animator.SetFloat("Horizontal", movement.x);
        if (movement.x != 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
