using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "Score : " + Score.score.ToString();
    }
}
