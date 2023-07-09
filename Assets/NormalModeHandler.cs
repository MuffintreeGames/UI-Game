using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalModeHandler : MonoBehaviour
{
    public static bool normalMode = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (normalMode)
        {
            GetComponent<Image>().enabled = true;
        } else
        {
            GetComponent<Image>().enabled = false;
        }
    }

    public static void ActivateNormalMode()
    {
        normalMode = true;
        //GetComponent<Image>().enabled = true;

    }
}
