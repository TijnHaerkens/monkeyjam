using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdd : MonoBehaviour
{
    public GameScoreBoard GameScoreBoardP1;
    public GameScoreBoard GameScoreBoardP2;
    public bool isTouch;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
/*    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == ("MonkeyBall1"))
        {
            Debug.Log("touch22");
            StartCoroutine(ScoreAdding());
            IEnumerator ScoreAdding()
            {
                GameScoreBoardP1.miniGamePlayerScore += 1;
                yield return new WaitForSeconds(0.1f);
                StartCoroutine(ScoreAdding());
            }

        }
        if (collision.gameObject.tag == ("MonkeyBall2"))
        {
            StartCoroutine(ScoreAdding());
            IEnumerator ScoreAdding()
            {
                GameScoreBoardP2.miniGamePlayerScore += 1;
                yield return new WaitForSeconds(0.1f);
                StartCoroutine(ScoreAdding());
            }

        }
    }
}*/



