using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endscore : MonoBehaviour
{
    [SerializeField] Text scoreTextPlayer1;
    [SerializeField] Text scoreTextPlayer2;
    [SerializeField] Text newScoreTextPlayer1;
    [SerializeField] Text newScoreTextPlayer2;
    public GameController GameController;
    public Animator transition;
    public Animator transition_end;
    public int currentScoreP1;
    public int currentScoreP2;
    public int newScoreP1;
    public int newScoreP2;

    float countSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        transition.SetTrigger("Start");
        currentScoreP1 = GameController.globalScorePlayer1;
        currentScoreP2 = GameController.globalScorePlayer2;

    }
    // Update is called once per frame
    void Update()
    {
        scoreTextPlayer1.text = currentScoreP1.ToString("0");
        scoreTextPlayer2.text = currentScoreP2.ToString("0");

        newScoreTextPlayer1.text = newScoreP1.ToString("0");
        newScoreTextPlayer2.text = newScoreP2.ToString("0");


    }

    public void AddNewScore()
    {

        StartCoroutine(Addingscore());
        IEnumerator Addingscore()
        {
            while (newScoreP1 > 0)
            {
                yield return new WaitForSeconds(0.2f * countSpeed);
                newScoreP1 -= 1;
                currentScoreP1 += 1;
                countSpeed -= 0.002f;

            }
            yield return new WaitForSeconds(1f);
            countSpeed = 0.2f;
            while (newScoreP2 > 0)
            {
                yield return new WaitForSeconds(0.2f * countSpeed);
                newScoreP2 -= 1;
                currentScoreP2 += 1;
                countSpeed -= 0.002f;

            }
            GameController.globalScorePlayer1 = currentScoreP1;
            GameController.globalScorePlayer2 = currentScoreP2;
            yield return new WaitForSeconds(1f);
            transition_end.SetTrigger("End");
            yield return new WaitForSeconds(0.3f);
            GameController.EndGameEnding();




        }

    }

}


