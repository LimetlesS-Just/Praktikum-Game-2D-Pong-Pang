using UnityEngine;
using TMPro;

public class BallBounce : MonoBehaviour
{
    public BallMovement ballMovement;
    public ScoreManager scoreManager;
    private void Bounce(Collision2D collision) 
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;
        if (collision.gameObject.tag == "Player1") {
            positionX = 1;
        } 
        else {
            positionX = -1;
        }

        float positionY = (ballPosition.y - racketPosition.y) / racketHeight;

        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2(positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.name == "Player 1" || collision.gameObject.name == "Player 2") 
        {
            Bounce(collision);
        }

        else if (collision.gameObject.name == "Right Bd") 
        {
            scoreManager.Player1Goal();
            ballMovement.player1Start = false;
            StartCoroutine(ballMovement.launch());
        }

        else if (collision.gameObject.name == "Left Bd") 
        {
            scoreManager.Player2Goal();
            ballMovement.player1Start = true;
            StartCoroutine(ballMovement.launch());
        }
    }
}
