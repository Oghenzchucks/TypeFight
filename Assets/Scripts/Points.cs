using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public float currentPoint;
    public float addedPoints = 5;
    public float fullPoints = 20;

    public static bool rageOn;

    public Slider slider;

    
    //Here we store the points that the player accumulates when he destroys the letter
    private void Start()
    {
        slider.maxValue = fullPoints;
        slider.minValue = 0;
    }

    //The method that add the points
    public void AddPoint()
    {
        if(currentPoint != fullPoints)
        {
            //when it is not max point yet
            currentPoint += addedPoints;
        }
        else
        {
            //when max point has been reached
            rageOn = true;  //Fever mode On
            currentPoint = 0;
        }
    }

    private void Update()
    {
        //controls the slider in the UI on the screen
        slider.value = currentPoint;
    }
}
