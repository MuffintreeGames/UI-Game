using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PianoController : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;
    public Button button8;
    public Button button9;

    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    public AudioSource sound4;
    public AudioSource sound5;
    public AudioSource sound6;
    public AudioSource sound7;
    public AudioSource sound8;
    public AudioSource sound9;

    public TextMeshProUGUI noteDisplay1;
    public TextMeshProUGUI noteDisplay2;
    public TextMeshProUGUI noteDisplay3;

    public float maxTimeBetweenNotes = 2f;
    float timeLeftToPlay = 0f;

    List<int> notesPlayed;

    /*bool countingDown = false;
    public float timeLimit = 10f;
    float timeLeft = 0f;*/

    public static GameObject coinSfx;
    static int[] coinNotes = { 2, 6, 7 };
    public static GameObject heartSfx;
    public static GameObject hitSfx;
    static List<GameObject> coinSfxList;
    static List<GameObject> heartSfxList;
    static List<GameObject> hitSfxList;
    // Start is called before the first frame update
    void Start()
    {
        coinSfx = (GameObject)Resources.Load("CoinSfx");
        coinSfxList = new List<GameObject>();
        heartSfxList = new List<GameObject>();
        hitSfxList = new List<GameObject>();
        notesPlayed = new List<int>();
        timeLeftToPlay = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        SoundSwitchboard();
        if (notesPlayed.Count >= 1)
        {
            noteDisplay1.text = notesPlayed[0].ToString();
        }
        if (notesPlayed.Count >= 2)
        {
            noteDisplay2.text = notesPlayed[1].ToString();
        }
        if (notesPlayed.Count >= 3)
        {
            noteDisplay3.text = notesPlayed[2].ToString();
        }
    }
    public void SoundSwitchboard()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) PlaySound1();
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) PlaySound2();
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) PlaySound3();
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) PlaySound4();
        if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)) PlaySound5();
        if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6)) PlaySound6();
        if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7)) PlaySound7();
        if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8)) PlaySound8();
        if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9)) PlaySound9();
    }
    public void PlaySound1()
    {
        sound1.Play();
        notesPlayed.Add(1);
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public void PlaySound2()
    {
        sound2.Play();
        notesPlayed.Add(2);
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public void PlaySound3()
    {
        sound3.Play();
        notesPlayed.Add(3);
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public void PlaySound4()
    {
        sound4.Play();
        notesPlayed.Add(4);
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public void PlaySound5()
    {
        sound5.Play();
        notesPlayed.Add(5);
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public void PlaySound6()
    {
        sound6.Play();
        notesPlayed.Add(6);
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public void PlaySound7()
    {
        sound7.Play();
        notesPlayed.Add(7);
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public void PlaySound8()
    {
        sound8.Play();
        notesPlayed.Add(8);
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public void PlaySound9()
    {
        // slide whistle/clown horn/meme sound? put next to keyboard?
        sound9.Play();
        notesPlayed.Add(9);
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public static void QueueCoinSfx()
    {
        GameObject sfx = Instantiate(coinSfx);
        coinSfxList.Add(sfx);
    }
}
