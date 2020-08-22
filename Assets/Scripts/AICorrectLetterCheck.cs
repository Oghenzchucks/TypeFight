using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AICorrectLetterCheck : MonoBehaviour
{
    public LetterGenerator letterGenerator;
    [HideInInspector] public string sentence;
    [HideInInspector] public int letterNum = 0;
    private int maxLetterNum;

    public Text showcurrentLetter;

    Points point;

    //private char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    private string[] alphabets = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };


    public GameObject player;
    private void Start()
    {
        sentence = letterGenerator.sentence;
        point = FindObjectOfType<Points>();
        maxLetterNum = sentence.Length;

        Debug.Log(alphabets.Length);
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
                showcurrentLetter.text = "Space";
            }
            else
            {
                showcurrentLetter.text = sentence[letterNum].ToString().ToUpper();
            }
        }
    }
    bool start;
    string currentLetter;
    IEnumerator AIChecker()
    {
        if (letterNum < maxLetterNum)
        {
            if (!start)
            {
                currentLetter = sentence[letterNum].ToString().ToUpper();

                //Checks for space in the current letter
                if (currentLetter == " ")
                {
                    currentLetter = "Space";
                }
                start = true;
            }

            //check if the input key string matches the current letter
            for(int i = 0; i < alphabets.Length; i++)
            {
                if (alphabets[i] == currentLetter)
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
        yield return new WaitForSeconds(5);
        StartCoroutine(AIChecker());
    }
}
