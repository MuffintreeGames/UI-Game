using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    private static int musicChoice = 0;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    private static int correctMusic = 0;
    bool countingDown = false;
    public float timeLimit = 5f;
    float timeLeft = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        button1.interactable = true;
        button2.interactable = true;
        button3.interactable = true;
        button4.interactable = true;
        switch(musicChoice)
        {
            case 0: button1.interactable = false; break;
            case 1: button2.interactable = false; break;
            case 2: button3.interactable = false; break;
            case 3: button4.interactable = false; break;
        }

        if (musicChoice != correctMusic)
        {
            if (!countingDown)
            {
                Debug.Log("Bad music! Starting countdown!");
                countingDown = true;
                timeLeft = timeLimit;
            }
            else
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0)
                {
                    Debug.Log("Ran out of time fixing music!");
                    string correctString = "";
                    string incorrectString = "";
                    switch (correctMusic)
                    {
                        case 0: correctString = "Forest"; break;
                        case 1: correctString = "Ice"; break;
                        case 2: correctString = "Cave"; break;
                        case 3: correctString = "Beach"; break;
                    }
                    switch (musicChoice)
                    {
                        case 0: incorrectString = "Forest"; break;
                        case 1: incorrectString = "Ice"; break;
                        case 2: incorrectString = "Cave"; break;
                        case 3: incorrectString = "Beach"; break;
                    }
                    GameOverManager.TriggerGameOver("Incorrect music: should have been " + correctString + " instead of " + incorrectString);
                }
            }
        }
        else
        {
            if (countingDown)
            {
                Debug.Log("Fixed music! Stopping countdown!");
                countingDown = false;
            }
        }
    }

    public void PlayMusic1()
    {
        musicChoice = 0;
    }

    public void PlayMusic2()
    {
        musicChoice = 1;
    }

    public void PlayMusic3()
    {
        musicChoice = 2;
    }

    public void PlayMusic4()
    {
        musicChoice = 3;
    }

    public static void SetCorrectMusic(int choice)
    {
        correctMusic = choice;
    }
}
