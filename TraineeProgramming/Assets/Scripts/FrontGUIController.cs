using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;
using System;

public class FrontGUIController : MonoBehaviour
{
    public static int LifeCount; // Количество жизней
    private int OldLifeCount; 

    public static int EquivalentPoint = 10; // Колличество баллов за один кирпич
    public static int Points; // Всего баллов
    private int OldPoints;  
    public static int Power; // бонусный коэффициент

    private StringBuilder PointsText = new StringBuilder(30);

    public GameObject PointsInfo;
    public static String Result = "";
    public static String StatusGame = "Старт";

    public GameObject Life;
    private List<GameObject> Lifes = new List<GameObject>();

    
    void Start()
    {
        LifeCount = 3;
        OldLifeCount = LifeCount;

        Points = 0;
        Power = 1;
        OldPoints = Points;

        Life.gameObject.SetActive(false);

        for (int i = 0; i < LifeCount; i++)
        { 
            GameObject obj = (GameObject)Instantiate(Life, Life.transform.position - new Vector3(-3 * i, 0, 0), Quaternion.identity, Life.transform.parent);
            obj.SetActive(true);
            Lifes.Add(obj);
        }
    }

    void Update()
    {
        if (LifeCount != OldLifeCount)
        {
            Lifes[LifeCount].SetActive(false);
            OldLifeCount = LifeCount;
        }

        if (Points != OldPoints)
        {
            PointsText.Length = 0;
            PointsText.Insert(0, Points + " points ");
            PointsInfo.GetComponent<Text>().text = PointsText.ToString();
            OldPoints = Points;
        }
    }

    private static void Exit()
    {
        SceneManager.LoadScene("Menu");
    }

    public static void GameEnd()
    {
        StatusGame = "Ещё раз";
        if (LifeCount > 1)
        {
            Result = "Вы выиграли! \n";
        } else
        {
            Result = "Вы проиграли! \n";
        }
        Result += "Ваш результат: " + Points;
        Exit();
    }
}
