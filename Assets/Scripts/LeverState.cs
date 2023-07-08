using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverState : MonoBehaviour
{
    public bool topRegion = true;
    public static bool isValid = false;
    public ScoreManager scoreManager;
    public SpriteRenderer spriteRenderer;
    public Sprite Up;
    public Sprite Down;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = transform.parent.gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        if (topRegion)
        {
            print("top region");
            if (Input.GetMouseButton(0)) // Returns true for every frame that the mouse is being pressed.
                isValid = true;
            else
                isValid = false;
        }
        else
        {
            print("bottom region");
            if (isValid && Input.GetMouseButtonDown(0))
            {
                spriteRenderer.sprite = Down;
            }
            else if (Input.GetMouseButtonUp(0)) {
                // play sound effect
                spriteRenderer.sprite = Up;
                scoreManager.Reset();
            }
        }
    }
}
