using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIHeart : MonoBehaviour
{
    public Sprite fullHeart;
    public Sprite crackedHeart;
    public Sprite emptyHeart;

    private float timeToAdd = 0.7f;
    bool held = false;
    float addTimeLeft = 0f;

    int taps = 0;
    public float resetTime = 3f;
    float resetTimeLeft;

    Image imageRenderer;
    bool heartActive = true;
    // Start is called before the first frame update
    void Start()
    {
        heartActive = true;
        held = false;
        imageRenderer = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!heartActive)
        {
            if (held)
            {
                addTimeLeft -= TimeController.AdjustedDeltaTime();
                if (addTimeLeft <= 0f)
                {
                    held = false;
                    AddHeart();
                }
            }
        } else
        {
            if (taps > 0)
            {
                resetTimeLeft -= TimeController.AdjustedDeltaTime();
                if (resetTimeLeft <= 0f)
                {
                    taps = 0;
                    imageRenderer.sprite = fullHeart;
                }
            }
        }
    }

    public void HeartHeld()
    {
        if (!heartActive && !held)
        {
            held = true;
            addTimeLeft = timeToAdd;
        }
    }

    public void HeartTapped()
    {
        if (heartActive)
        {
            taps += 1;
            if (taps < 3)
            {
                imageRenderer.sprite = crackedHeart;
                resetTimeLeft = resetTime;
            } else
            {
                LoseHeart();
            }
        }
    }

    public void AddHeart()
    {
        Debug.Log("adding heart!");
        heartActive = true;
        imageRenderer.sprite = fullHeart;
    }

    public void LoseHeart()
    {
        Debug.Log("losing heart!");
        heartActive = false;
        taps = 0;
        imageRenderer.sprite = emptyHeart;
    }
}
