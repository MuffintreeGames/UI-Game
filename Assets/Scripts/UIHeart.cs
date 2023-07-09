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

    private float timeToAdd = 0.4f;
    bool held = false;
    float addTimeLeft = 0f;

    int taps = 0;
    public float resetTime = 3f;
    float resetTimeLeft;

    private float blackness = 0f;
    Image imageRenderer;
    bool heartActive = true;
    // Start is called before the first frame update
    void Start()
    {
        heartActive = true;
        held = false;
        imageRenderer = GetComponent<Image>();
        blackness = 0f;
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
                } else
                {
                    blackness = addTimeLeft / timeToAdd;
                }
            } else
            {
                blackness = 1f;
            }
        } else
        {
            if (taps > 0)
            {
                resetTimeLeft -= TimeController.AdjustedDeltaTime();
                if (resetTimeLeft <= 0f)
                {
                    taps = 0;
                    //imageRenderer.sprite = fullHeart;
                }
            } else
            {
                blackness = 0f;
            }
        }
        imageRenderer.color = new Color(1f - blackness, 1f - blackness, 1f - blackness);
        if (deactivateWasPreviouslyHeld)
        {
            wasPreviouslyHeld = false;
            deactivateWasPreviouslyHeld = false;
        }
    }

    bool wasPreviouslyHeld = false;
    bool deactivateWasPreviouslyHeld = false;
    public void HeartHeld()
    {
        if (!heartActive && !held)
        {
            held = true;
            addTimeLeft = timeToAdd;
            wasPreviouslyHeld = true;
        }
    }

    public void HeartReleased()
    {
        if (!heartActive && held)
        {
            held = false;
        }
        deactivateWasPreviouslyHeld = true;
    }

    public void HeartTapped()
    {
        if (heartActive && !wasPreviouslyHeld)
        {
            taps += 1;
            if (taps < 3)
            {
                //imageRenderer.sprite = crackedHeart;
                resetTimeLeft = resetTime;
                blackness = .33f * taps;
            } else
            {
                LoseHeart();
            }
        }
        deactivateWasPreviouslyHeld = true;
    }

    public void AddHeart()
    {
        heartActive = true;
        blackness = 0f;
        //imageRenderer.sprite = fullHeart;
    }

    public void LoseHeart()
    {
        heartActive = false;
        taps = 0;
        blackness = 1f;
        //imageRenderer.sprite = emptyHeart;
    }

    public bool IsHeartActive()
    {
        return heartActive;
    }
}
