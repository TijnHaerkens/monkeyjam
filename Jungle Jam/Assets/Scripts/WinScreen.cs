using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public float countSpeed = 0.001f;
    public float nearEndScore = 100;
    public int shakeSpeed;
    public int scoreWinner;

    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;

    public StaticValue staticValue;
    public LevelLoader levelLoader;

    public Animator transition;
    public Animator scoreReveal;
    public Animator healthReveal;

    public Animator monkeyRise;
    public Sprite MoneyImg01;
    public Sprite MoneyImg02;

    public GameObject fadeBlack;
    public AudioClip winnerRevealSound;
    public AudioSource audioSource;

    [SerializeField] Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = StaticValue.winnerMaxHealth;
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);

        nearEndScore = StaticValue.winnerScore;
        nearEndScore -= nearEndScore / 2;

        if (StaticValue.winner == 1)
        {
            monkeyRise.gameObject.GetComponent<Image>().sprite = MoneyImg01;
        }
        else if (StaticValue.winner == 2)
        {
            monkeyRise.gameObject.GetComponent<Image>().sprite = MoneyImg02;
        }
        else
        {

        }

        //Maybe DEL later
        scoreWinner = StaticValue.winnerScore;
        currentHealth = StaticValue.winnerCurrentHealth;


        healthBar.gameObject.SetActive(false);
        monkeyRise.gameObject.SetActive(false);






        StartCoroutine(RevealWinner());

        IEnumerator RevealWinner()
        {
            audioSource.PlayOneShot(winnerRevealSound);
            yield return new WaitForSeconds(1.5f);
            transition.SetTrigger("Start");
            
            yield return new WaitForSeconds(0.5f);
            Destroy(fadeBlack);
            monkeyRise.gameObject.SetActive(true);
            monkeyRise.SetTrigger("Start");

            yield return new WaitForSeconds(1f);
            scoreReveal.SetTrigger("Start");


            yield return new WaitForSeconds(1f);
            healthBar.gameObject.SetActive(true);
            healthReveal.SetTrigger("Start");
            Addscore();

        }
        
    }
    public void Addscore()
    {
        StartCoroutine(Addingscore());
        IEnumerator Addingscore()
        {
           /* while (scoreWinner < StaticValue.winnerScore)
            {
                if (scoreWinner < StaticValue.winnerScore)
                {
                    yield return new WaitForSeconds(0.5f - countSpeed + Time.deltaTime);
                    scoreWinner += 1;
                    

                    if (scoreWinner < nearEndScore)
                    {

                        countSpeed += 0.025f;

                    }
                    else
                    {
                        countSpeed -= 0.025f;

                    }

                    

                }

            }

            yield return new WaitForSeconds(1f);
            while (currentHealth >= StaticValue.winnerCurrentHealth)
            {

                if (currentHealth > StaticValue.winnerCurrentHealth + 100)
                {

                    currentHealth -= 20;

                }
                else
                {
                    currentHealth -= 1;
                }
                yield return new WaitForSeconds(0.001f);




            }*/
            yield return new WaitForSeconds(7f);
            EndGameExitMainMenu();

        }
    }

            // Update is called once per frame
            void Update()
    {

        healthBar.SetHealth(currentHealth);
        scoreText.text = scoreWinner.ToString("0");

        Debug.Log("current heath: " + currentHealth);
        Debug.Log("max heath: " + maxHealth);
            }

    public void EndGameExitMainMenu()
    {
        
        StaticValue.globalScorePlayer1 = 0;
        StaticValue.globalScorePlayer2 = 0;
        StaticValue.globalHealthPlayer1 = 0;
        StaticValue.globalHealthPlayer2 = 0;
        StaticValue.globalMaxHealthPlayer1 = 0;
        StaticValue.globalMaxHealthPlayer2 = 0;
        StaticValue.winner = 0;
        StaticValue.winnerScore = 0;
        StaticValue.winnerCurrentHealth = 0;
        StaticValue.winnerMaxHealth = 0;
        levelLoader.ExitToMenu();
    }
}
