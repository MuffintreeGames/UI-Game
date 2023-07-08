using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    static string GameOverCause = "unknown";
    static int Score = 0;

    public TextMeshProUGUI causeText;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null) { 
            scoreText.text = Score.ToString();
        }

        if (causeText != null)
        {
            causeText.text = GameOverCause;
        }
    }

    public static void TriggerGameOver(string cause)
    {
        GameOverCause = cause;
        Score = (int)TimeController.GetTimePlayed();
        SceneManager.LoadScene("GameOver");
    }
}
