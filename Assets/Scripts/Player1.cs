using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float racketSpeed;
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
        float directionY = Input.GetAxisRaw("Vertical");
        racketDirection = new Vector2(0, directionY).normalized;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = racketDirection * racketSpeed;
    }
}
