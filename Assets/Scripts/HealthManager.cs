using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public UIHeart heart1;
    public UIHeart heart2;
    public UIHeart heart3;

    private int currentHealth = 3;
    private static int correctHealth = 3;

    public float timeLimit = 3f;
    bool countingDown = false;
    float timeLeft = 0f;

    bool requireReset = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 3;
        correctHealth = 3;
        countingDown = false;
        requireReset = false;
        timeLimit = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = 0;
        if (heart1.IsHeartActive())
        {
            currentHealth += 1;
        }
        if (heart2.IsHeartActive())
        {
            currentHealth += 1;
        }
        if (heart3.IsHeartActive())
        {
            currentHealth += 1;
        }
        if (currentHealth == 0)
        {
            requireReset = true;
            correctHealth = 1; 
        }
        
        if (currentHealth != correctHealth || requireReset)
        {
            if (!countingDown)
            {
                Debug.Log("Bad health! Starting countdown!");
                countingDown = true;
                timeLeft = timeLimit;
            }
            else
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0)
                {
                    if (currentHealth != correctHealth)
                    {
                        Debug.Log("Ran out of time fixing health!");
                        GameOverManager.TriggerGameOver("Incorrect health: should have been " + correctHealth + " instead of " + currentHealth);
                    }
                    else
                    {
                        Debug.Log("Ran out of time to reset game!");
                        GameOverManager.TriggerGameOver("Failed to reset after losing all hearts");
                    }
                }
            }
        } else
        {
            if (countingDown)
            {
                Debug.Log("Fixed health! Stopping countdown!");
                countingDown = false;
                requireReset = false;
            }
        }
    }

    public static void TakeDamage() {
        correctHealth -= 1;
        if (correctHealth < 0)
        {
            correctHealth = 0;
        }
    }

    public static void GainHealth(int value)
    {
        correctHealth += value;
        if (correctHealth > 3)
        {
            correctHealth = 3;
        }
    }
}
