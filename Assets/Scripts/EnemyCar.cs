using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCar : MonoBehaviour
{
    public float movementSpeed = 1f;
    public int lane = 3;

    public GameObject player;

    public Rigidbody2D rb;

    public UnityEvent CarDestroyed;

    Vector2 movement;

    void Update()
    {
        movement.y = -1;

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y < -128)
        {
            player.GetComponent<PlayerMovement>().IncreaseScore();
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
