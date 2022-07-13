using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CircleFill : MonoBehaviour
{
    public CountDownTimer CountDown;
    public GameController CountDownGameControlller;
    public Transform loadingBar;
    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;
    private float startValue;
    // Start is called before the first frame update
    void Start()
    {
        CountDown = FindObjectOfType<CountDownTimer>();


        //Via Countdown
        /*startValue = CountDown.startingTimer;*/

        //Via Gamecontroller
        startValue = CountDownGameControlller.MiniGameCountDownTimer;
    }

    // Update is called once per frame
    void Update()
    {
        currentAmount = CountDown.currentTime;
        loadingBar.GetComponent<Image>().fillAmount = currentAmount / startValue;
    }
}
