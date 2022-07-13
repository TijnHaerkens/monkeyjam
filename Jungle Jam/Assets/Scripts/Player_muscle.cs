using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_muscle : MonoBehaviour
{
    public int maxMuscle = 200;
    public int currentMuscle = 0;
    public int musclebuild = 25;
    public Musclebar musclebar;


    public int maxMiniMuscle = 5;
    public int currentMiniMuscle = 0;
    public int minimusclebuild = 5;
    public Musclebar minimusclebar;

    public int muscleStage = 0;

    public int scoreMultiply = 1;

    private float nextActionTime = 0.0f;
    public float period = 0.02f;

    private bool buttonOne = true;
    private bool playGame = true;
    public GameScoreBoard GameScoreBoard;
    public GameController gameController;

    public Sprite playerUp;
    public Sprite playerDown;

    public GameObject player;


    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode right = KeyCode.D;
    // Start is called before the first frame update
    void Start()
    {

        musclebar.SetMaxMuscle(maxMuscle);
        musclebar.SetMuscle(currentMuscle);

        minimusclebar.SetMaxMuscle(maxMiniMuscle);
        minimusclebar.SetMuscle(currentMiniMuscle);

        player.gameObject.GetComponent<SpriteRenderer>().sprite = playerDown;
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Every period the muscle meter loses 1 count
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            LoseMuscle(1);
        }


        if (currentMuscle <= 0)
        {
            currentMuscle = 0;
        }



        if (Input.GetKeyDown(left) && buttonOne == true && playGame == true)
        {
            BuildMuscle();
            buttonOne = false;
            player.gameObject.GetComponent<SpriteRenderer>().sprite = playerUp;
        }
        if (Input.GetKeyDown(right) && buttonOne == false && playGame == true)
        {
            BuildMuscle();
            buttonOne = true;
            player.gameObject.GetComponent<SpriteRenderer>().sprite = playerDown;
        }






        if (currentMuscle >= maxMuscle && muscleStage == 4)
        {
            GameScoreBoard.miniGamePlayerScore += 500;
            currentMuscle = 0;
            muscleStage += 1;
            musclebuild -= 3;
            minimusclebar.SetMuscle(muscleStage);

        }
        else if (currentMuscle >= maxMuscle)
        {
            currentMuscle = 0;
            muscleStage += 1;
            musclebuild -= 3;
            minimusclebar.SetMuscle(muscleStage);
            GameScoreBoard.miniGamePlayerScore += 20 * scoreMultiply * muscleStage;
            scoreMultiply += 1;
        }

        /*        if (muscleStage == 3)
                {
                    maxMuscle = 500;
                    musclebar.SetMaxMuscle(maxMuscle);
                    musclebar.SetMuscle(currentMuscle);
                    musclebuild = 35;
                    period = 0.005f;

                }*/

        if (muscleStage == 5)
        {
            MuscleWin();
        }
    }



void BuildMuscle()
    {
        GameScoreBoard.miniGamePlayerScore += 1;
        currentMuscle += musclebuild;
        musclebar.SetMuscle(currentMuscle);
        
    }
    void LoseMuscle(int musclelost)
    {
        currentMuscle -= musclelost;
        musclebar.SetMuscle(currentMuscle);
    }
    void MuscleWin()
    {
        playGame = false;
        currentMuscle = 0;
        gameController.EndGame();
    }
}
