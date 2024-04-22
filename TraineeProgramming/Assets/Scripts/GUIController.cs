using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public GameObject indicatorGame;
    public GameObject pointsText;
    public GameObject life;
    public Button exitButton;

    private List<GameObject> lifes = new List<GameObject>();

    void Start()
    {
        Button btn = exitButton.GetComponent<Button>();
        btn.onClick.AddListener(exitOnClick);

        life.SetActive(false);

        for (int i = 0; i < indicatorGame.GetComponent<IndicatorGame>().getCountLife(); i++)
        {
            GameObject obj = (GameObject)Instantiate(life, life.transform.position - new Vector3(-3 * i, 0, 0), Quaternion.identity, life.transform.parent);
            obj.SetActive(true);
            lifes.Add(obj);
        }
    }

    public void removeLifeGUI()
    {
        lifes[indicatorGame.GetComponent<IndicatorGame>().getCountLife()].SetActive(false);
    }

    public void changePointGUI()
    {
        pointsText.GetComponent<Text>().text = indicatorGame.GetComponent<IndicatorGame>().getPoints() + " points";
    }

    public void exitOnClick()
    {
        Application.Quit();
    }
}
