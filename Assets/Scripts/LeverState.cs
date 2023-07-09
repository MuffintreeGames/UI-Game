using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LeverState : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool topRegion = true;
    public static bool isValid = false;
    public ScoreManager scoreManager;
    public Image spriteRenderer;
    public Sprite Up;
    public Sprite Down;
    private bool mouse_over = false;
    public AudioSource leverSound;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = transform.parent.gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (mouse_over && topRegion)
        {
            //print("top region");
            if (Input.GetMouseButton(0)) {
                // Returns true for every frame that the mouse is being pressed.
                //print("isValid = true");
                isValid = true;
                }
            else
            {
                 isValid = false;
                 //print("isValid = false");
            }
        }
        else if ((mouse_over && !topRegion))
        {
            //print("bottom region");
            if (isValid && Input.GetMouseButton(0))
            {
                print("sprite down");
                spriteRenderer.sprite = Down;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                print("sprite up");
                spriteRenderer.sprite = Up;
                scoreManager.Reset();
                isValid = false;
                leverSound.Play();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        Debug.Log("Mouse exit");
        if (!topRegion && isValid)
        {
            print("sprite up");
            spriteRenderer.sprite = Up;
            scoreManager.Reset();
            isValid = false;
            leverSound.Play();
        }
    }
}
