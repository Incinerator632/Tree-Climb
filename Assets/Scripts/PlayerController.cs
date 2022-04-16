using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player2Rb2d;
    private float speed = 10f;
    private float horizontalInput;
    private float xRange = 15;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player2Rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        player2Rb2d.velocity = new Vector2(horizontalInput * speed, player2Rb2d.velocity.y);
    }
}
