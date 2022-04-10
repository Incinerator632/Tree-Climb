using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D player2Rb2d = collision.gameObject.GetComponent<Rigidbody2D>();
            if (player2Rb2d != null)
            {
                Vector2 velocity = player2Rb2d.velocity;
                velocity.y = jumpForce;
                player2Rb2d.velocity = velocity;
            }
        }
        Score.scoreValue += 10;
    }
}
