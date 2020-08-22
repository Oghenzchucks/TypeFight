using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public bool reached;
    public float speed;
    float timer;

    CorrectLetterCheck correct;

    [Range(10,50)]
    public float rageMoveDistance = 20;
    void Start()
    {
        correct = FindObjectOfType<CorrectLetterCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        //moves player when the correct letter has been pressed
        if (reached)
        {
            //character moves here normally
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }


        //When it has accumulated the maximum point this will give the player ability to dash through multiple letter blocks
        if (Points.rageOn)
        {
            timer += 0.5f;

            //ragemoveDistance is the maximum time the rage should last for
            if(timer < rageMoveDistance)
            {
                //character moves here when it is in rage mode
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else
            {
                timer = 0;
                Points.rageOn = false;  //Fever mode Off
            }
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //What happens when it collides with the letter
        if (collision.gameObject.CompareTag("Letters"))
        {
            if (!Points.rageOn)
            {
                //what happens when it is normal
                reached = false;
                speed = 0;
            }
            else
            {
                //what happens when it is in rage form
                correct.letterNum++;
            }
            collision.gameObject.SetActive(false);
        }
    }
}
