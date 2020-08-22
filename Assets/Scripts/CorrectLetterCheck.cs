using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectLetterCheck : MonoBehaviour
{
    public LetterGenerator letterGenerator;
    [HideInInspector] public string sentence;
    [HideInInspector] public int letterNum = 0;
    private int maxLetterNum;

    public Text currentLetter;

    Points point;

    public GameObject player;
    private void Start()
    {
        sentence = letterGenerator.sentence;
        point = FindObjectOfType<Points>();
        maxLetterNum = sentence.Length;
    }

    private void Update()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                Debug.Log("KeyCode down: " + kcode);
                // Checks if the correct letter and input match
                if (letterNum < maxLetterNum)
                {
                    string currentLetter = sentence[letterNum].ToString().ToUpper();

                    //Checks for space in the current letter
                    if (currentLetter == " ")
                    {
                        currentLetter = "Space";
                    }

                    //check if the input key string matches the current letter
                    if (kcode.ToString() == currentLetter)
                    {
                        Debug.Log("correct");
                        //what happens when the currentLetter matches the press key
                        letterNum++;

                        // Moves the player
                        player.GetComponent<MovePlayer>().reached = true;
                        player.GetComponent<MovePlayer>().speed = 10;

                        //Adds the points
                        point.AddPoint();
                    }
                    else
                    {
                        //player fails to destroy. Pressed the wrong key
                        Debug.Log("wrong");
                    }


                }
            }
        }


        //Prints out the letter to the UI
        if(letterNum < maxLetterNum)
        {
            //Checks for space in the current letter
            if (sentence[letterNum].ToString().ToUpper() == " ")
            {
                currentLetter.text = "Space";
            }
            else
            {
                currentLetter.text = sentence[letterNum].ToString().ToUpper();
            }
        }
    }
}
