using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public StaticValue staticValue;
    private static List<int> scenes = new List<int>() { 1, 2, 3, 4 };

    // Start is called before the first frame update
    public void LoadMinigame(string sceneName)
    {
        StartCoroutine(LoadLevel());

        IEnumerator LoadLevel()
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(sceneName);
        }
    }
    // Update is called once per frame
        
    void Update()
    {

        //remove me later and set me on a different script THIS IS JUST FOR TESTING
        /*        if (Input.GetKeyDown(KeyCode.Keypad5))
                {
                    LoadMinigame("scoreEND");
                }*/
        if (Input.GetKey("escape"))
        {
            ExitGameEscape();
        }

    }
    public void RandomMiniGame()
    {
        /*        int randomLevel = Random.Range(1, 3);
                if (randomLevel == 1)
                {
                    LoadMinigame("Minigame01");
                }
                else if (randomLevel == 2)
                {
                    LoadMinigame("Minigame02");
                }        else if (randomLevel == 3)
                {
                    LoadMinigame("Minigame03");
                }        else if (randomLevel == 4)
                {
                    LoadMinigame("Minigame04");
                }*/
        if (StaticValue.level == 3)
        {
            LoadMinigame("ScoreEND");
        }
        else
        {
            StaticValue.level += 1;

            int index = Random.Range(0, scenes.Count);
            int scene = scenes[index];
            scenes.RemoveAt(index);
            StartCoroutine(LoadNextLevel());

            IEnumerator LoadNextLevel()
            {
                transition.SetTrigger("Start");

                yield return new WaitForSeconds(transitionTime);

                SceneManager.LoadScene(scene);
            }
            
        }

    }  
    
    public void ExitGameEscape()
    {
        StartCoroutine(ExitGame());

        IEnumerator ExitGame()
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(transitionTime);

            Application.Quit();
        }

    }

    public void WinGame(int winner)
    {
        if (winner == 1)
        {
            StaticValue.winner = 1;
            LoadMinigame("WinnerScreen");
        }
        else if (winner == 2)
        {
            StaticValue.winner = 2;
            LoadMinigame("WinnerScreen");
        }
        else if (winner == 3)
        {
            StaticValue.winner = 3;
            LoadMinigame("WinnerScreen");
        }
    }
    public void ExitToMenu()
    {
        LoadMinigame("MainMenu");
    }
}
