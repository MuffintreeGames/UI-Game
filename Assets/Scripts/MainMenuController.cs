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
        GameObject.Find("SoundPlayer").GetComponent<AudioSource>().Play();
        GameObject.Find("MusicPlayer").GetComponent<MenuMusic>().StopMusic();
        NormalModeHandler.DeactivateNormalMode();
        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "MainGame"));
    }

    public void LoadNormal()
    {
        GameObject.Find("SoundPlayer").GetComponent<AudioSource>().Play();
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
        GameObject.Find("SoundPlayer").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Instructions");
    }

    public void LoadInstructions2()
    {
        GameObject.Find("SoundPlayer").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Instructions2");
    }

    public void ReturnToTitle()
    {
        GameObject.Find("SoundPlayer").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("MainMenu");
    }
}
