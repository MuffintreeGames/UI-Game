using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    public GameObject neutralFace;
    public GameObject scaredFace;
    public GameObject happyFace;
    public GameObject speedUp;

    float happyTime = 2f;
    float happyTimeLeft = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeController.timeLeftInDisplaySpeedup > 0f)
        {
            speedUp.SetActive(true);
            scaredFace.SetActive(false);
            happyFace.SetActive(false);
            neutralFace.SetActive(false);
            return;
        }
    if (PianoController.IsCountingDown() || MusicController.IsCountingDown() || HealthManager.IsCountingDown() || ScoreManager.IsCountingDown() || TimerController.IsCountingDown())
        {
            scaredFace.SetActive(true);
            happyFace.SetActive(false);
            speedUp.SetActive(false);
            neutralFace.SetActive(false);
        } else
        {
            if (scaredFace.activeSelf || happyTimeLeft > 0f)
            {
                happyFace.SetActive(true);
                scaredFace.SetActive(false);
                speedUp.SetActive(false);
                neutralFace.SetActive(false);
                if (happyTimeLeft <= 0f)
                {
                    happyTimeLeft = happyTime;
                } else
                {
                    happyTimeLeft -= Time.deltaTime;
                }
            } else
            {
                neutralFace.SetActive(true);
                scaredFace.SetActive(false);
                happyFace.SetActive(false);
                speedUp.SetActive(false);
            }
        }

    }
}
