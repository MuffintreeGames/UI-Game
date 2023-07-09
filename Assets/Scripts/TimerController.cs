using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public Image timer;
    public TextMeshProUGUI timePlayed;

    public static float timeLimit = 30f;
    public static float timeLeft = 30f;
    public static float timeIncrement = 10f;

    // Update is called once per frame

    void Start()
    {
        timeLeft = 30f;
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
            GameOverManager.TriggerGameOver("Times up! Remember to wind up the timer!");
        }
    }

    public static void AddTime()
    {
        timeLeft += timeIncrement;
        if (timeLeft > timeLimit) timeLeft = timeLimit;
    }

    void UpdateTimePlayed()
    {
        timePlayed.text = ((int)TimeController.GetTimePlayed()).ToString();
    }
}

