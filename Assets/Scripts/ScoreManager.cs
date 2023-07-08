using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI thousands;
    public TextMeshProUGUI hundreds;
    public TextMeshProUGUI tens;
    public TextMeshProUGUI ones;

    public float timeLimit = 5f;
    bool countingDown = false;
    float timeLeft = 0f;

    public static int correctScore = 0;
    int currentScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        correctScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = (int.Parse(thousands.text) * 1000) + (int.Parse(hundreds.text) * 100) + (int.Parse(tens.text) * 10) + int.Parse(ones.text);
        if (currentScore != correctScore) {
            if (!countingDown)
            {
                Debug.Log("Bad score! Starting countdown!");
                countingDown = true;
                timeLeft = timeLimit;
            }
            else
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0)
                {
                        Debug.Log("Ran out of time fixing score!");
                        GameOverManager.TriggerGameOver("Incorrect score: should have been " + correctScore + " instead of " + currentScore);
                }
            }
        } else
        {
            if (countingDown)
            {
                Debug.Log("Fixed score! Stopping countdown!");
                countingDown = false;
            }
        }
    }

    public static void GainPoints(int points)
    {
        correctScore += points;
    }

    public void Reset()
    {
        thousands.text = 0.ToString();
        hundreds.text = 0.ToString();
        tens.text = 0.ToString();
        ones.text = 0.ToString();
    }

    public void IncreaseThousands()
    {
        int value = int.Parse(thousands.text);
        value += 1;
        if (value > 9)
        {
            value = 0;
        }
        thousands.text = value.ToString();
    }

    public void DecreaseThousands()
    {
        int value = int.Parse(thousands.text);
        value -= 1;
        if (value < 0)
        {
            value = 9;
        }
        thousands.text = value.ToString();
    }

    public void IncreaseHundreds()
    {
        int value = int.Parse(hundreds.text);
        value += 1;
        if (value > 9)
        {
            value = 0;
        }
        hundreds.text = value.ToString();
    }

    public void DecreaseHundreds()
    {
        int value = int.Parse(hundreds.text);
        value -= 1;
        if (value < 0)
        {
            value = 9;
        }
        hundreds.text = value.ToString();
    }

    public void IncreaseTens()
    {
        int value = int.Parse(tens.text);
        value += 5;
        if (value > 9)
        {
            value = 0;
        }
        tens.text = value.ToString();
    }

    public void DecreaseTens()
    {
        int value = int.Parse(tens.text);
        value -= 5;
        if (value < 0)
        {
            value = 5;
        }
        tens.text = value.ToString();
    }

    public void IncreaseOnes()
    {
        int value = int.Parse(ones.text);
        value += 5;
        if (value > 9)
        {
            value = 0;
        }
        ones.text = value.ToString();
    }

    public void DecreaseOnes()
    {
        int value = int.Parse(ones.text);
        value -= 5;
        if (value < 0)
        {
            value = 5;
        }
        ones.text = value.ToString();
    }
}
