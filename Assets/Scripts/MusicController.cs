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

    AudioSource music1;
    AudioSource music2;
    AudioSource music3;
    AudioSource music4;
    AudioSource currentMusic;

    private static int correctMusic = 0;
    static bool countingDown = false;
    public float timeLimit = 5f;
    static float timeLeft = 0f;
    // Start is called before the first frame update
    void Start()
    {
        correctMusic = 0;
        musicChoice = 0;
        countingDown = false;
        music1 = button1.GetComponent<AudioSource>();
        music2 = button2.GetComponent<AudioSource>();
        music3 = button3.GetComponent<AudioSource>();
        music4 = button4.GetComponent<AudioSource>();
        currentMusic = music1;
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
        float musicTime = currentMusic.time;
        currentMusic.Stop();
        musicChoice = 0;
        currentMusic = music1;
        music1.time = musicTime;
        music1.Play();
    }

    public void PlayMusic2()
    {
        float musicTime = currentMusic.time;
        currentMusic.Stop();
        musicChoice = 1;
        currentMusic = music2;
        music2.time = musicTime;
        music2.Play();
    }

    public void PlayMusic3()
    {
        float musicTime = currentMusic.time;
        currentMusic.Stop();
        musicChoice = 2;
        currentMusic = music3;
        music3.time = musicTime;
        music3.Play();
    }

    public void PlayMusic4()
    {
        float musicTime = currentMusic.time;
        currentMusic.Stop();
        musicChoice = 3;
        currentMusic = music4;
        music4.time = musicTime;
        music4.Play();
    }

    public static void SetCorrectMusic(int choice)
    {
        correctMusic = choice;
        if (countingDown)
        {
            timeLeft += 1;
        }
    }
}
