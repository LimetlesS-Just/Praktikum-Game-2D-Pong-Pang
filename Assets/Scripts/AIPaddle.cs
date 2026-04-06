using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public float racketSpeed;
    public Transform ball;
    private Rigidbody2D rb;
    private Vector2 racketDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.position.y > transform.position.y + 1.0f) {
            racketDirection = new Vector2(0, 1);
        } 
        else if (ball.position.y < transform.position.y - 1.0f) {
            racketDirection = new Vector2(0, -1);
        } 
        else {
            racketDirection = new Vector2(0, 0);
        }
    }

    void FixedUpdate() {
        rb.linearVelocity = racketDirection * racketSpeed;
    }
}
