using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public Image timer;
    public TextMeshProUGUI timePlayed;

    float internalTime = 0f;

    public static float timeLimit = 30f;
    public static float timeLeft = 30f;
    public static float timeIncrement = 10f;

    // Update is called once per frame

    void Start()
    {
        timeLeft = 30f;
        internalTime = 0f;
    }
    void Update()
    {
        UpdateTimePlayed();
        if (timeLeft > 0)
        {
            timeLeft -= TimeController.AdjustedDeltaTime();
            timer.fillAmount = timeLeft / timeLimit;
        }
        else
        {
            Debug.Log("Ran out of time fixing timer!");
            GameOverManager.TriggerGameOver("Time's up! Remember to wind up the timer!");
        }
    }

    public static void AddTime()
    {
        timeLeft += timeIncrement;
        if (timeLeft > timeLimit) timeLeft = timeLimit;
    }

    void UpdateTimePlayed()
    {
        internalTime += TimeController.AdjustedDeltaTime();
        timePlayed.text = ((int)internalTime).ToString();
    }

    public static bool IsCountingDown()
    {
        return timeLeft < 7f;
    }

    public void ResetTime()
    {
        internalTime = 0f;
    }
}

