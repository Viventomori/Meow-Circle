using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour
{
    public int score;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;//point count         
    }
}
