using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{

    public float currentTime = 0f;
    public float startingTimer = 30f;

    [SerializeField] Text CountDownText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTimer;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        CountDownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;

        }
    }
}
