using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public CountDownTimer CountDownTimer;
    public Endscore endScore;
    public GameObject healthBar;
    public GameObject bananaSpawner;
    public GameObject countDown;
    public GameScoreBoard GameScoreBoardP1;
    public GameScoreBoard GameScoreBoardP2;
    public playermovement Player1_movement;
    public playermovement Player2_movement;
    public Player_Movement_Game2 player1_Movement_Game2;
    public Player_Movement_Game2 player2_Movement_Game2;
    public Shootingscript shootingScriptP1;
    public shootingscript2 shootingScriptP2;
    public Player_Health Player_Health1;
    public Player_Health Player_Health2;
    public Player_muscle Player_muscle1;
    public Player_muscle Player_muscle2;
    public Spawner_Game2 spawner_Game2;

    public StaticValue staticValue;

    public LevelLoader LevelLoader;

    public int miniGameLevel;
    public static int globalScorePlayer1;
    public static int globalScorePlayer2;
    public static int globalHealthPlayer1 = 500;
    public static int globalHealthPlayer2 = 500;
    public static bool setGlobalMaxHealth = false;
    public float MiniGameCountDownTimer = 30f;

    public bool gameEndDone = false;

    public Animator transition;
    public Animator transitionCameraMuscle;
    public Animator transitionMuscleBar;
    public float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        Player_Health1.currentHealth = globalHealthPlayer1;
        Player_Health2.currentHealth = globalHealthPlayer2;
        if (globalHealthPlayer1 < Player_Health1.maxHealth)
        {
            Player_Health1.currentHealth = globalHealthPlayer1;
        }

        CountDownTimer.startingTimer = MiniGameCountDownTimer;
        DisableGame();


        if (setGlobalMaxHealth == false)
        {
            StaticValue.globalMaxHealthPlayer1 = globalHealthPlayer1;
            StaticValue.globalMaxHealthPlayer2 = globalHealthPlayer2;
            setGlobalMaxHealth = true;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (CountDownTimer.currentTime <= 0 && gameEndDone == false)
        {
            EndGame();

            gameEndDone = true;
        }
        Debug.Log(globalHealthPlayer1);

         StaticValue.globalScorePlayer1 = globalScorePlayer1;
        StaticValue.globalScorePlayer2 = globalScorePlayer2;
        StaticValue.globalHealthPlayer1 = globalHealthPlayer1;
        StaticValue.globalHealthPlayer2 = globalHealthPlayer2;


        if (miniGameLevel == 2 && CountDownTimer.currentTime <= 2)
        {
            shootingScriptP1.enabled = false;
            shootingScriptP2.enabled = false;
            Debug.Log("3eererer");
        }
}
    public void DisableGame()
    {
        /*CountDownTimer.gameObject.SetActive(false);*/
        endScore.gameObject.SetActive(false);
        GameScoreBoardP1.gameObject.SetActive(false);
        GameScoreBoardP2.gameObject.SetActive(false);
        CountDownTimer.enabled = false;


        if (miniGameLevel == 1)
        {
            Player1_movement.enabled = false;
            Player2_movement.enabled = false;
        }
        else if (miniGameLevel == 2)
        {
            player1_Movement_Game2.enabled = false;
            player2_Movement_Game2.enabled = false;
            shootingScriptP1.enabled = false;
            shootingScriptP2.enabled = false;
        }
        else if (miniGameLevel == 3)
        {
/*            Player_muscle1.enabled = false;
            Player_muscle2.enabled = false;*/

        }
        else if (miniGameLevel == 4)
        {
            spawner_Game2.enabled = false;
            player1_Movement_Game2.enabled = false;
            player2_Movement_Game2.enabled = false;
        }
        else if (miniGameLevel == 5)
        {

        }
        else if (miniGameLevel == 6)
        {
            healthBar.gameObject.SetActive(false);
        }

    }
    void StartGame()
    {
        if (miniGameLevel == 1)
        {

        }
        else if (miniGameLevel == 2)
        {
            player1_Movement_Game2.enabled = true;
            player2_Movement_Game2.enabled = true;
        }
        else if (miniGameLevel == 3)
        {

            transitionCameraMuscle.SetTrigger("Start");
            transitionMuscleBar.SetTrigger("Start");

        }
        else if (miniGameLevel == 4)
        {
            
            player1_Movement_Game2.enabled = true;
            player2_Movement_Game2.enabled = true;
        }
        else if (miniGameLevel == 5)
        {

        }
        else if (miniGameLevel == 6)
        {

        }

    }

    public void EnableGame()
    {


        if (miniGameLevel == 1)
        {
            healthBar.gameObject.SetActive(true);
            bananaSpawner.gameObject.SetActive(true);
            GameScoreBoardP1.gameObject.SetActive(true);
            GameScoreBoardP2.gameObject.SetActive(true);

            CountDownTimer.enabled = true;
            Player1_movement.enabled = true;
            Player2_movement.enabled = true;
        }
        else if (miniGameLevel == 2)
        {
            healthBar.gameObject.SetActive(true);
            GameScoreBoardP1.gameObject.SetActive(true);
            GameScoreBoardP2.gameObject.SetActive(true);

            CountDownTimer.enabled = true;
            player1_Movement_Game2.enabled = true;
            player2_Movement_Game2.enabled = true;

            shootingScriptP1.enabled = true;
            shootingScriptP2.enabled = true;
        }
        else if (miniGameLevel == 3)
        {
            healthBar.gameObject.SetActive(true);
            GameScoreBoardP1.gameObject.SetActive(true);
            GameScoreBoardP2.gameObject.SetActive(true);

            Player_muscle1.enabled = true;
            Player_muscle2.enabled = true;
            CountDownTimer.enabled = true;
            Player1_movement.enabled = false;
            Player2_movement.enabled = false;
        }
        else if (miniGameLevel == 4)
        {
            healthBar.gameObject.SetActive(true);
            GameScoreBoardP1.gameObject.SetActive(true);
            GameScoreBoardP2.gameObject.SetActive(true);

            spawner_Game2.enabled = true;
            CountDownTimer.enabled = true;
            player1_Movement_Game2.enabled = true;
            player2_Movement_Game2.enabled = true;

        }
        else if (miniGameLevel == 5)
        {

        }
        else if (miniGameLevel == 6)
        {

        }

    }
    public void SetHealth()
    {


    }
    public void EndGame()
    {
        if (miniGameLevel == 1)
        {
            bananaSpawner.gameObject.SetActive(false);
        }
        globalHealthPlayer1 = Player_Health1.currentHealth;
        globalHealthPlayer2 = Player_Health2.currentHealth;

        SetHealth();

        healthBar.gameObject.SetActive(false);
        countDown.gameObject.SetActive(false);
        transition.SetTrigger("Start");

        DisableGame();
        endScore.newScoreP1 = GameScoreBoardP1.miniGamePlayerScore;
        endScore.newScoreP2 = GameScoreBoardP2.miniGamePlayerScore;
        DisableGame();
        StartCoroutine(AddScoreTimer());
        /*        endScore.enabled = true;*/
        IEnumerator AddScoreTimer()
        {

                yield return new WaitForSeconds(1f);
            endScore.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            endScore.AddNewScore();


        }

    }
    public void EndGameEnding()
    {

        Debug.Log("END MINIGAME");
        /*        LevelLoader.LoadMinigame("Minigame01");*/
        LevelLoader.RandomMiniGame();
    }


}

