using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCountdown : MonoBehaviour
{

    public GameController GameController;
 public float currentTime = 0f;
public float startingTimer = 10f;
    public Image Background;
[SerializeField] Text CountDownText;
// Start is called before the first frame update
void Start()
{
    currentTime = startingTimer;
        Background.gameObject.SetActive(true);
    }

// Update is called once per frame
void Update()
{
    currentTime -= 1 * Time.deltaTime;
    CountDownText.text = currentTime.ToString("0");

    if (currentTime <= 0)
    {
            GameController.EnableGame();
            CountDownText.gameObject.SetActive(false);
            currentTime = 9999999999;
            Background.gameObject.SetActive(false);
        }
}
}
