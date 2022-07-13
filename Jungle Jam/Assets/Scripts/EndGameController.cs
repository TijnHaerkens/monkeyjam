using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{
    public int maxHealthP1;
    public int currentHealthP1;
    public HealthBar healthBarP1;
    public Health_Face_Hud healthFaceP1;

    public int maxHealthP2;
    public int currentHealthP2;
    public HealthBar healthBarP2;
    public Health_Face_Hud healthFaceP2;

    public StaticValue staticValue;

    [SerializeField] Text scoreTextP1;
    [SerializeField] Text scoreTextP2;

    public Animator switchScore1;
    public Animator switchScore2;
    public Animator healthBar1;

    public int scorePlayer1;
    public int scorePlayer2;

    private float countSpeed = 0.001f;
    private float shakeSpeed = 0f;
    private int nearEndScoreP1 = 0;
    private int nearEndScoreP2 = 0;

    private bool scoreCount1;
    private bool scoreCount2;

    private bool finishedCount = false;

    private float healthBarShakeSpeedP1 = 15f;
    private float healthBarShakeSpeedP2 = 15f;

    public AudioClip scorePing;
    public AudioSource audioSource;

    public LevelLoader levelLoader;

    public GameObject prefabScoreAddP1;
    public GameObject prefabScoreAddP2;
    // Start is called before the first frame update
    void Start()
    {
        maxHealthP1 = StaticValue.globalMaxHealthPlayer1;
        maxHealthP2 = StaticValue.globalMaxHealthPlayer2;

        healthBarP1.SetMaxHealth(maxHealthP1);
        healthBarP2.SetMaxHealth(maxHealthP2);

        currentHealthP1 = StaticValue.globalHealthPlayer1;
        currentHealthP2 = StaticValue.globalHealthPlayer2;

        nearEndScoreP1 = StaticValue.globalScorePlayer1;
        nearEndScoreP2 = StaticValue.globalScorePlayer2;
        nearEndScoreP1 -= nearEndScoreP1 / 2;
        nearEndScoreP1 += 5;

        nearEndScoreP2 -= nearEndScoreP2 / 2;
        nearEndScoreP2 += 5;
        /*tartScoreHealth();*/
        Addscore();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealthP1 == 0)
        {
            CheckHealth();
        }
        if (currentHealthP2 == 0)
        {
            CheckHealth();
        }


        healthBarP1.SetHealth(currentHealthP1);
        healthBarP2.SetHealth(currentHealthP2);

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            TakeDamage(20);
        }
        Debug.Log(currentHealthP1);

        scoreTextP1.text = scorePlayer1.ToString("0");
        scoreTextP2.text = scorePlayer2.ToString("0");


        shakeSpeed = countSpeed;
        if (countSpeed > 3)
        {
            if (scoreCount1 == true)
            {
                switchScore1.SetBool("Shake", true);
            }
            else if (scoreCount2 == true)
            {
                switchScore2.SetBool("Shake", true);
            }



        }

        if (shakeSpeed < 1)
        {

            switchScore1.SetBool("Shake", false);

            switchScore2.SetBool("Shake", false);

            shakeSpeed = 0;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealthP1 -= damage;
        /*healthBar.SetHealth(currentHealth);*/
        healthFaceP1.PlayerHurtImage();
    }
    public void Addscore()
    {
        StartCoroutine(Addingscore());
        IEnumerator Addingscore()
        {
            scoreCount1 = true;
            yield return new WaitForSeconds(3f);
            while (scorePlayer1 < StaticValue.globalScorePlayer1)
            {

                yield return new WaitForSeconds(0.5f - countSpeed + Time.deltaTime);
                scorePlayer1 += 1;
                audioSource.PlayOneShot(scorePing);

                if (scorePlayer1 < nearEndScoreP1)
                {

                    countSpeed += 0.025f;

                }
                else
                {
                    countSpeed -= 0.025f;

                }

                switchScore1.SetFloat("Speed", shakeSpeed);
            }
            scoreCount1 = false;
            yield return new WaitForSeconds(2f);
            switchScore1.SetBool("Shake", false);
            countSpeed = 0.001f;
            shakeSpeed = 0f;
            while (scorePlayer2 < StaticValue.globalScorePlayer2)
            {
                scoreCount2 = true;
                yield return new WaitForSeconds(0.5f - countSpeed + Time.deltaTime);
                scorePlayer2 += 1;
                if (scorePlayer2 < nearEndScoreP2)
                {

                    countSpeed += 0.025f;

                }
                else
                {
                    countSpeed -= 0.025f;

                }
                switchScore2.SetFloat("Speed", shakeSpeed);
            }
            StartScoreHealth();

        }
    }

    public void StartScoreHealth()
    {
        StartCoroutine(startScoreAdding());
        IEnumerator startScoreAdding()
        {

            yield return new WaitForSeconds(1f);
            SwitchScore();
            yield return new WaitForSeconds(1f);

            Attack();


        }

    }

    public void SwitchScore()
    {
        switchScore1.SetTrigger("Switch");
        switchScore2.SetTrigger("Switch");
    }

    public void Attack()
    {

        Debug.Log("start attack");
        StartCoroutine(Attacking());
        IEnumerator Attacking()
        {

            yield return new WaitForSeconds(3f);


            while (finishedCount == false && currentHealthP1 >= 0 && currentHealthP2 >= 0)
            {

                yield return new WaitForSeconds(0.01f);
                if (scorePlayer1 > 0)
                {
                    /*Instantiate(prefabScoreAddP1, new Vector3(0, 0, 0), Quaternion.identity);*/
                    currentHealthP2 -= 1;
                    scorePlayer1 -= 1;
                }
                if (scorePlayer2 > 0)
                {
                    currentHealthP1 -= 1;
                    scorePlayer2 -= 1;

                }
                if (scorePlayer1 == 0 && scorePlayer2 == 0)
                {
                    finishedCount = true;
                }



            }
            yield return new WaitForSeconds(1f);
            CheckHealth();
        }

    }

    public void ShowScoreAdd()
    {
        Instantiate(prefabScoreAddP1, transform.position, Quaternion.identity);
    }    
    public void CheckHealth()
    {
        if (currentHealthP1 > currentHealthP2)
        {
            StaticValue.winnerScore = StaticValue.globalScorePlayer1;
            StaticValue.winnerCurrentHealth = currentHealthP1;
            StaticValue.winnerMaxHealth = StaticValue.globalMaxHealthPlayer1;

            levelLoader.WinGame(1);
        }
        else if (currentHealthP2 > currentHealthP1)
        {
            StaticValue.winnerScore = StaticValue.globalScorePlayer2;
            StaticValue.winnerCurrentHealth = currentHealthP2;
            StaticValue.winnerMaxHealth = StaticValue.globalMaxHealthPlayer2;

            levelLoader.WinGame(2);
        }
        else if (currentHealthP1 == currentHealthP2)
        {
            levelLoader.WinGame(3);
        }
    }
}
