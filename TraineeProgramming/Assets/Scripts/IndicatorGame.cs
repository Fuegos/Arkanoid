using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorGame : MonoBehaviour
{
    private int pointForBreackingBrick = 10;
    private int totalPoints = 0;
    private int bonus = 1;
    private int lifeCount = 3;

    public void calcPointsForBreackingBreak()
    {
        totalPoints += bonus * pointForBreackingBrick;
    }

    public int getPoints() { return totalPoints; }

    public void addBonus() { bonus++; }

    public void resetBonus() { bonus = 1; }

    public int getCountLife() { return lifeCount; }

    public void removeLife() { lifeCount--; }

    public string getResult()
    {
        string result = "";

        if (lifeCount > 1)
        {
            result = "You are win! \n";
        }
        else
        {
            result = "You are lose! \n";
        }
        result += "Your result: " + totalPoints;

        return result;
    }
}
