using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float powerupScoreIncrease = 50.0f;
    public float powerupScoreDecrease = 100.0f;
    public float powerupTimeIncrease = 20.0f;
    public float powerupTimeDecrease = 30.0f;
    public bool hasPowerup = false;
    public bool hasPowerup2 = false;
    public bool hasPowerup3 = false;
    public bool hasPowerup4 = false;
    private Rigidbody2D player2Rb2d;
    private GameManager gameManager;
    private float speed = 10f;
    private float horizontalInput;
    private float xRange = 14;

    // Start is called before the first frame update
    void Start()
    {
        player2Rb2d = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }

        if (other.CompareTag("Powerup2"))
        {
            hasPowerup2 = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }

        if (other.CompareTag("Powerup3"))
        {
            hasPowerup3 = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }

        if (other.CompareTag("Powerup4"))
        {
            hasPowerup4 = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }

        IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(5);
            hasPowerup = false;
        }
    }
}
