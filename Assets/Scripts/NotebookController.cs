using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookController : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    // Start is called before the first frame update
    void Start()
    {
        OpenPage1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPage1()
    {
        page1.SetActive(true);
        page2.SetActive(false);
    }

    public void OpenPage2()
    {
        page2.SetActive(true);
        page1.SetActive(false);
    }
}
