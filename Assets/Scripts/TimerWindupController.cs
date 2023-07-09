using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimerWindupController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int currentSection = 0;
    public static int lastSection = 0;
    public static bool isValid = false;
    private bool mouse_over = false;
    public AudioSource windupSound;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (!mouse_over) return;
        if (!isValid) lastSection = 0;
        if (currentSection == lastSection + 1 && Input.GetMouseButton(0))
        {
            isValid = true;

        }  else
        {
            isValid = false;
        }
        if (isValid && currentSection == 4) { 
                isValid = false;
                TimerController.AddTime();
                windupSound.Play();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        Debug.Log("Mouse enter");
        if (!Input.GetMouseButton(0)) isValid = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        lastSection = currentSection;
    }
}
