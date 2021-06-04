using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlatformSpeed = 1f;
    public float BallSpeed = 1f;

    public Transform LeftBorder;
    public Transform RightBorder;
    public Rigidbody Ball;
    public Transform Init;
    
    bool m_Hold = true;
    Vector3 m_LeftPosition;
    Vector3 m_RightPosition;
    float CurrentPosition = 0.5f;

    float OldMouseX;

    void Start()
    {
        m_LeftPosition = LeftBorder.position;
        m_RightPosition = RightBorder.position;

        Ball.GetComponent<BallController>().Dead += Dead;
        Ball.GetComponent<BallController>().Win += Win;

        OldMouseX = Input.mousePosition.x;
    }

    void OnDestroy()
    {
        Ball.GetComponent<BallController>().Dead -= Dead;
        Ball.GetComponent<BallController>().Win -= Win;
    }
     
    void Update()
    {
    }

    private void FixedUpdate()
    {
        var dir = Vector3.right;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x < OldMouseX)
        {
            dir = Vector3.left;

            CurrentPosition -= Time.deltaTime * PlatformSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x > OldMouseX)
        {
            CurrentPosition += Time.deltaTime * PlatformSpeed;
        }
        
        if (m_Hold)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                m_Hold = false;
                Ball.velocity = (Vector3.up + dir) * BallSpeed;
            }
            else
            {
                Ball.MovePosition(Init.position);
            }
        }
        
        transform.position = Vector3.Lerp(m_LeftPosition, m_RightPosition, CurrentPosition);

        if (Screen.width / 2 - 100 < Input.mousePosition.x && Input.mousePosition.x < Screen.width / 2 + 100)
        {
            OldMouseX = Input.mousePosition.x;
        }
    }

    void Dead()
    {
        Hold();
    }

    void Win()
    {
        Hold();
    }

    void Hold()
    {
        Ball.velocity = Vector3.zero;
        m_Hold = true;
    }
}