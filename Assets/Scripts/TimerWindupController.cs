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
    public static int consecutiveSections = 0;
    private bool mouse_over = false;
    public AudioSource windupSound;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (!mouse_over) return;
        //if (!isValid) lastSection = 0;
        if (Input.GetMouseButtonDown(0))
        {
            lastSection = currentSection - 1;
        }
        if (currentSection == lastSection + 1 && Input.GetMouseButton(0))
        {
            isValid = true;

        }  else
        {
            isValid = false;
            consecutiveSections = 0;
        }
        /*if (isValid && currentSection == 4) { 
                isValid = false;
                TimerController.AddTime();
                windupSound.Play();
        }*/
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        Debug.Log("Mouse enter");
        if (!Input.GetMouseButton(0)) { isValid = false; consecutiveSections = 0; }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        lastSection = currentSection;
        if (lastSection == 4)
        {
            lastSection = 0;
        }
        if (isValid)
        {
            consecutiveSections++;
            if (consecutiveSections == 4) {
                consecutiveSections = 0;
                TimerController.AddTime();
                windupSound.Play();
            }
        }
    }
}
