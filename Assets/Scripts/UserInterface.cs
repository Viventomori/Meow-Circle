using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    public Text timerText;
    private int sec = 0;
    private int min = 0;
    private int delta = 0; //time change

    private void Start()
    {
        Time.timeScale = 0;//start with 0 value time
        StartCoroutine(TimeRun());
    }

    public void StartStop(int delta)//0 & 1 time
    {
        this.delta = delta;
        Time.timeScale = delta;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator TimeRun()//function time
    {
        while (true)
        {
            if (sec == 59)
            {
                min++;
                sec = -1;
            }
            sec += delta;
            timerText.text = min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }
}
