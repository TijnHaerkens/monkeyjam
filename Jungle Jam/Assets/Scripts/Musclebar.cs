using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Musclebar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxMuscle(int muscle)
    {
        slider.maxValue = muscle;
        slider.value = muscle;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetMuscle(int muscle)
    {
        slider.value = muscle;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
