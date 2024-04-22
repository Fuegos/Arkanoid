using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject ballController;
    public float platformSpeed = 1.5f;
    public Transform leftBorder;
    public Transform rightBorder;
 
    private float currentPosition = 0.5f;
    private float oldMouseX;

    void Start()
    {
        oldMouseX = Input.mousePosition.x;
    }


    private void FixedUpdate()
    {
        var direction = Vector3.right;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x < oldMouseX)
        {
            direction = Vector3.left;
            currentPosition -= Time.deltaTime * platformSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x > oldMouseX)
        {
            currentPosition += Time.deltaTime * platformSpeed;
        }
        
        if(!ballController.GetComponent<BallController>().getIsMoving())
        {
            if(Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
            {
                ballController.GetComponent<BallController>().startMoving(direction);
            }
            else
            {
                ballController.GetComponent<BallController>().setPlatformPosition();
            }
        }
        
        transform.position = Vector3.Lerp(leftBorder.position, rightBorder.position, currentPosition);

        if (Screen.width / 2 - 100 < Input.mousePosition.x && Input.mousePosition.x < Screen.width / 2 + 100)
        {
            oldMouseX = Input.mousePosition.x;
        }
    }
}