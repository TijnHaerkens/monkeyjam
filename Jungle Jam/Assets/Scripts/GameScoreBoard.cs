using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScoreBoard : MonoBehaviour
{
    [SerializeField] Text scoreText;
    public int miniGamePlayerScore;
    // Start is called before the first frame update
    void Start()
    {
        //TEMP CODE REMOVE LATER
       /* miniGamePlayerScore = Random.Range(10,30);*/
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = miniGamePlayerScore.ToString("0");
    }
}
