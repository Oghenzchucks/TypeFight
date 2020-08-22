using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterGenerator : MonoBehaviour
{
    public GameObject prefab;
    public string sentence;
    public Transform parent;
    private void Start()
    {
        //start position for the 1st cube letter to be generated
        Vector3 pos = new Vector3(transform.position.x, 2, -5);

        //create the cube and set the letters in the string to a cube
        for (int i = 0; i < sentence.Length; i++)
        {
            GameObject letterBox = Instantiate(prefab, pos, prefab.transform.rotation, parent);
            letterBox.GetComponentInChildren<Text>().text = sentence[i].ToString();
            pos.z -= 5;
        }
    }
}
