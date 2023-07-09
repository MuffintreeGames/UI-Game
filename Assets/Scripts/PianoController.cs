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

    public static GameObject coinSfx;
    static int[] coinNotes = { 2, 6, 7 };
    public static GameObject heartSfx;
    static int[] heartNotes = { 3, 4, 5 };
    public static GameObject hitSfx;
    static int[] hitNotes = { 1, 3, 1 };
    public static GameObject deathSfx;
    static int[] deathNotes = { 8, 4, 1 };
    static List<GameObject> coinSfxList;
    static List<GameObject> heartSfxList;
    static List<GameObject> hitSfxList;
    static List<GameObject> deathSfxList;
    // Start is called before the first frame update
    void Start()
    {
        coinSfx = (GameObject)Resources.Load("CoinSfx");
        heartSfx = (GameObject)Resources.Load("HeartSfx");
        hitSfx = (GameObject)Resources.Load("HitSfx");
        deathSfx = (GameObject)Resources.Load("DeathSfx");
        coinSfxList = new List<GameObject>();
        heartSfxList = new List<GameObject>();
        hitSfxList = new List<GameObject>();
        deathSfxList = new List<GameObject>();
        notesPlayed = new List<int>();
        timeLeftToPlay = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (NormalModeHandler.normalMode)
        {
            return;
        }
        SoundSwitchboard();
        if (timeLeftToPlay > 0f)
        {
            timeLeftToPlay -= Time.deltaTime;
            if (timeLeftToPlay <= 0f)
            {
                ResetNoteDisplay();
            }
        }
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

    public void ResetNoteDisplay()
    {
        notesPlayed.Clear();
        noteDisplay1.text = "";
        noteDisplay2.text = "";
        noteDisplay3.text = "";
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

    void CheckNotesPlayed()
    {
        if (notesPlayed[0] == coinNotes[0] && notesPlayed[1] == coinNotes[1] && notesPlayed[2] == coinNotes[2])
        {
            Debug.Log("played coin sound!");
            if (coinSfxList.Count > 0)
            {
                Destroy(coinSfxList[0]);
                coinSfxList.RemoveAt(0);
            }
            return;
        } else if (notesPlayed[0] == heartNotes[0] && notesPlayed[1] == heartNotes[1] && notesPlayed[2] == heartNotes[2])
        {
            Debug.Log("played heart sound!");
            if (heartSfxList.Count > 0)
            {
                Destroy(heartSfxList[0]);
                heartSfxList.RemoveAt(0);
            }
        } else if (notesPlayed[0] == hitNotes[0] && notesPlayed[1] == hitNotes[1] && notesPlayed[2] == hitNotes[2])
        {
            Debug.Log("played hit sound!");
            if (hitSfxList.Count > 0)
            {
                Destroy(hitSfxList[0]);
                hitSfxList.RemoveAt(0);
            }
        } else if (notesPlayed[0] == deathNotes[0] && notesPlayed[1] == deathNotes[1] && notesPlayed[2] == deathNotes[2])
        {
            Debug.Log("played death sound!");
            if (deathSfxList.Count > 0)
            {
                Destroy(deathSfxList[0]);
                deathSfxList.RemoveAt(0);
            }
        }
    }

    public void PlaySound1()
    {
        sound1.Play();
        if (notesPlayed.Count > 2)
        {
            ResetNoteDisplay();
        }
        notesPlayed.Add(1);
        if (notesPlayed.Count == 3)
        {
            CheckNotesPlayed();
        }
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public void PlaySound2()
    {
        sound2.Play();
        if (notesPlayed.Count > 2)
        {
            ResetNoteDisplay();
        }
        notesPlayed.Add(2);
        if (notesPlayed.Count == 3)
        {
            CheckNotesPlayed();
        }
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public void PlaySound3()
    {
        sound3.Play();
        if (notesPlayed.Count > 2)
        {
            ResetNoteDisplay();
        }
        notesPlayed.Add(3);
        if (notesPlayed.Count == 3)
        {
            CheckNotesPlayed();
        }
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public void PlaySound4()
    {
        sound4.Play();
        if (notesPlayed.Count > 2)
        {
            ResetNoteDisplay();
        }
        notesPlayed.Add(4);
        if (notesPlayed.Count == 3)
        {
            CheckNotesPlayed();
        }
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public void PlaySound5()
    {
        sound5.Play();
        if (notesPlayed.Count > 2)
        {
            ResetNoteDisplay();
        }
        notesPlayed.Add(5);
        if (notesPlayed.Count == 3)
        {
            CheckNotesPlayed();
        }
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public void PlaySound6()
    {
        sound6.Play();
        if (notesPlayed.Count > 2)
        {
            ResetNoteDisplay();
        }
        notesPlayed.Add(6);
        if (notesPlayed.Count == 3)
        {
            CheckNotesPlayed();
        }
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public void PlaySound7()
    {
        sound7.Play();
        if (notesPlayed.Count > 2)
        {
            ResetNoteDisplay();
        }
        notesPlayed.Add(7);
        if (notesPlayed.Count == 3)
        {
            CheckNotesPlayed();
        }
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public void PlaySound8()
    {
        sound8.Play();
        if (notesPlayed.Count > 2)
        {
            ResetNoteDisplay();
        }
        notesPlayed.Add(8);
        if (notesPlayed.Count == 3)
        {
            CheckNotesPlayed();
        }
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public void PlaySound9()
    {
        sound9.Play();
        /*if (notesPlayed.Count > 2)
        {
            ResetNoteDisplay();
        }
        notesPlayed.Add(9);
        if (notesPlayed.Count == 3)
        {
            CheckNotesPlayed();
        }*/
        ResetNoteDisplay();
        timeLeftToPlay = 0f;
        timeLeftToPlay = maxTimeBetweenNotes;
    }

    public static void QueueCoinSfx()
    {
        if (NormalModeHandler.normalMode)
        {
            return;
        }
        GameObject sfx = Instantiate(coinSfx);
        coinSfxList.Add(sfx);
    }

    public static void QueueHeartSfx()
    {
        if (NormalModeHandler.normalMode)
        {
            return;
        }
        GameObject sfx = Instantiate(heartSfx);
        heartSfxList.Add(sfx);
    }

    public static void QueueHitSfx()
    {
        if (NormalModeHandler.normalMode)
        {
            return;
        }
        GameObject sfx = Instantiate(hitSfx);
        hitSfxList.Add(sfx);
    }

    public static void QueueDeathSfx()
    {
        if (NormalModeHandler.normalMode)
        {
            return;
        }
        GameObject sfx = Instantiate(deathSfx);
        deathSfxList.Add(sfx);
    }

    public static bool IsCountingDown()
    {
        return (coinSfxList.Count > 0 || heartSfxList.Count > 0 || hitSfxList.Count > 0 || deathSfxList.Count > 0);
    }
}
