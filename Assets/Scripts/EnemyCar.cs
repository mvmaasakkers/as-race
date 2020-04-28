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
    public GameObject explosion;
    Vector2 movement;

    public float removeOnY = -128f;

    void Update()
    {
        movement.y = -1;

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y < removeOnY)
        {
            player.GetComponent<PlayerMovement>().IncreaseScore();
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
