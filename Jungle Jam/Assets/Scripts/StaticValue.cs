using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StaticValue : MonoBehaviour
{

    // values are temp... remove later
    public static int level;
    public static int globalScorePlayer1;
    public static int globalScorePlayer2;
    public static int globalHealthPlayer1;
    public static int globalHealthPlayer2;
    public static int globalMaxHealthPlayer1;
    public static int globalMaxHealthPlayer2;
    public static int winner = 10; // Dont remove this value
    public static int winnerScore;
    public static int winnerCurrentHealth;
    public static int winnerMaxHealth;

    void Update()
    {
        Debug.Log(globalMaxHealthPlayer1);
        Debug.Log("winner:" + winner);

    }
    public void ClearValues()
    {
        level = 0;
        globalScorePlayer1 = 0;
        globalScorePlayer2 = 0;
        globalHealthPlayer1 = 0;
        globalHealthPlayer2 = 0;
        globalMaxHealthPlayer1 = 0;
        globalMaxHealthPlayer2 = 0;
        winner = 0;
        winnerScore = 0;
        winnerCurrentHealth = 0;
        winnerMaxHealth = 0;
}
}
