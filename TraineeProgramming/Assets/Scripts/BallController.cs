using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Transform platformPosition;
    public GameObject gameController;
    public float ballSpeed = 15f;
    public Rigidbody ball;

    private bool isMoving = false;

    public bool getIsMoving() { return isMoving; }

    public void startMoving(Vector3 direction)
    {
        isMoving = true;
        ball.velocity = (Vector3.up + direction) * ballSpeed;
    }

    public void resetBall()
    {
        isMoving = false;
        ball.velocity = Vector3.zero;
        setPlatformPosition();
    }

    public void setPlatformPosition()
    {
        ball.MovePosition(platformPosition.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameController.GetComponent<GameController>().handleBallsCollision(collision);
    }
}