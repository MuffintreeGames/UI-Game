using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        GameObject.Find("MusicPlayer").GetComponent<MenuMusic>().StopMusic();
        NormalModeHandler.DeactivateNormalMode();
        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "MainGame"));
    }

    public void LoadNormal()
    {
        GameObject.Find("MusicPlayer").GetComponent<MenuMusic>().StopMusic();
        NormalModeHandler.ActivateNormalMode();
        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "MainGame"));
    }

    public void LoadCredits()
    {
        GameObject.Find("SoundPlayer").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Credits");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
