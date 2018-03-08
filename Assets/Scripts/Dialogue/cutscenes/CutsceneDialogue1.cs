using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneDialogue1 : MonoBehaviour {

    public string[] dialogueLines;
    public float delay; // seconds between characters
    public float multiplier; // increase speed when key held

    public KeyCode DialogueInput = KeyCode.Space;

    private bool stringShown;
    private bool dialoguePlaying;
    private bool endOfDialogue;
    private Text textComp;

    public GameObject instruction;

	// Use this for initialization
	void Start ()
    {
        delay = 0.15f;
        multiplier = 0.5f;
        stringShown = false;
        dialoguePlaying = false;
        endOfDialogue = false;
        textComp = GetComponent<Text>();
        textComp.text = "";

        HideIcon();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!dialoguePlaying)
            {
                dialoguePlaying = true;
                StartCoroutine(StartDialogue());
            }
        }
	}

    //starts dialogue array
    private IEnumerator StartDialogue()
    {
        int length = dialogueLines.Length;
        int index = 0;

        while (index < length)
        {
            if (!stringShown)
            {
                stringShown = true;
                StartCoroutine(DisplayString(dialogueLines[index]));
                index++;

                if (index >= length)
                {
                    endOfDialogue = true;
                }
            }

            yield return 0;
        }

        // pauses dialogue once whole string displayed
        while (true)
        {
            if (Input.GetKeyDown(DialogueInput))
            {
                break;
            }

            yield return 0;
        }

        if (endOfDialogue && index >= length)
        {
            Complete();
        }

        HideIcon();
        endOfDialogue = false;
        dialoguePlaying = false;
    }

    // displays dialogue lines
    private IEnumerator DisplayString(string dialogue)
    {
        int length = dialogue.Length;
        int index = 0;

        HideIcon();

        textComp.text = "";

        // while lines of dialogue still remain in array
        while(index < length)
        {
            textComp.text += dialogue[index];
            index++;

            // repetitive; clean up later
            if (index < length)
            {
                // hold to make dialogue go faster
                if (Input.GetKey(DialogueInput))
                {
                    // waits given time in between each char
                    yield return new WaitForSeconds(delay * multiplier); 
                }
                else
                {
                    // default dialogue speed
                    yield return new WaitForSeconds(delay);
                }
            }
            else
            {
                break;
            }
        }

        ShowIcon();

        while (true)
        {
            if (Input.GetKeyDown(DialogueInput))
            {
                break;
            }

            yield return 0;
        }

        HideIcon();
        stringShown = false;
        textComp.text = "";
    }


    // hide instruction icon
    private void HideIcon()
    {
        instruction.SetActive(false);
    }

    // show instruction icon to prompt player to continue
    private void ShowIcon()
    {
        instruction.SetActive(true);
    }

    void Complete()
    {
        SceneManager.LoadScene("Level1");
    }

}
