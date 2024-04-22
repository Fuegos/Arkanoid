using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public GameObject GUIController;
    public GameObject indicatorGame;
    public GameObject ballController;
    public GameObject gridController;

    void Start()
    {
        gridController.GetComponent<GridController>().generateBricks();
    }

    void Update()
    {
        if (gridController.GetComponent<GridController>().getBrickCount() <= 0)
        {
            goToMenu();
        }
    }

    public void goToMenu()
    {
        PlayerPrefs.SetString("result", indicatorGame.GetComponent<IndicatorGame>().getResult());
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }


    public void handleBallsCollision(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "DeadZone":
                if (indicatorGame.GetComponent<IndicatorGame>().getCountLife() > 1)
                {
                    indicatorGame.GetComponent<IndicatorGame>().removeLife();
                    GUIController.GetComponent<GUIController>().removeLifeGUI();
                    indicatorGame.GetComponent<IndicatorGame>().resetBonus();
                    ballController.GetComponent<BallController>().resetBall();
                }
                else
                {
                    goToMenu();
                }
                break;

            case "Brick":
                gridController.GetComponent<GridController>().destroyBrick(collision.gameObject);
                indicatorGame.GetComponent<IndicatorGame>().calcPointsForBreackingBreak();
                indicatorGame.GetComponent<IndicatorGame>().addBonus();
                GUIController.GetComponent<GUIController>().changePointGUI();
                break;

            case "Player":
                indicatorGame.GetComponent<IndicatorGame>().resetBonus();
                break;
        }
    }
}
