using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    private const int LvlChange = 50;//up speed with next lvl
    public CircleGenerator circleManager;
    private ScoreCounter scoreCounter; 

    void Start()
    {
        scoreCounter = Camera.main.GetComponent<ScoreCounter>();
    }

    private void FixedUpdate()
    {
        if (scoreCounter.score > 500)//need points to next lvl
        {
            ChangeLevel();
        }
    }

    void ChangeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//next lvl
        CircleGenerator.slowly -= LvlChange;//grow up speed
    }
}
