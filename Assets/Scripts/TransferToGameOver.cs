using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransferToGameOver : MonoBehaviour
{
    float delayToGameOver = 1f;
    float delayLeft = 0f;
    public bool turnedOn = false;

    bool firstTurnedOnFrame = true;
    // Start is called before the first frame update
    void Start()
    {
        delayLeft = delayToGameOver;
        turnedOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!turnedOn)
        {
            return;
        }
        if (firstTurnedOnFrame)
        {
            firstTurnedOnFrame = false;
            GetComponent<Image>().enabled = true;
            GetComponent<AudioSource>().Play();
        }
        delayLeft -= Time.deltaTime;
        if (delayLeft <= 0f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
