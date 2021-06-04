using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Action Dead;
    public Action Win;

    void Start()
    {
        
    }


    void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("DeadZone"))
        {
            if (FrontGUIController.LifeCount > 1)
            {
                FrontGUIController.LifeCount--;
                FrontGUIController.Power = 1;
            } else
            {
                FrontGUIController.GameEnd();
            }
            Dead?.Invoke();
        }

        else if (other.gameObject.CompareTag("Brick"))
        {
            Destroy(other.gameObject);

            GridGenerator.BrickCount--;

            FrontGUIController.Points += FrontGUIController.Power * FrontGUIController.EquivalentPoint;
            FrontGUIController.Power++;
            

            if (GridGenerator.BrickCount <= 0)
            {
                Win?.Invoke();
                FrontGUIController.GameEnd();
            }
        }

        else if (other.gameObject.CompareTag("Player"))
        {
            FrontGUIController.Power = 1;
        }
    }
}