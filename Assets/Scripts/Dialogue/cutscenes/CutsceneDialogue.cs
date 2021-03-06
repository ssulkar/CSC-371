﻿/* This entire script was written by Michael Lozada */
/* With edits by Aidan to the complete function to load levels in the right order*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneDialogue : MonoBehaviour {

    public string[] dialogueLines;
    public float delay; // seconds between characters
    public float multiplier; // increase speed when key held

    public KeyCode DialogueInput = KeyCode.Return; // progresses dialogue to next element in array

    private bool stringShown;
    private bool dialoguePlaying;
    private bool endOfDialogue;
    private Text textComp;

    public GameObject instruction;

	// Use this for initialization
	void Start ()
    {
        delay = 0.1f;
        multiplier = 0.1f;
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
        if (Input.GetKeyUp(KeyCode.Return))
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


    // loads the correct level or cutscene dependent on where the user is in the story
    void Complete()
    {
        Scene scene = SceneManager.GetActiveScene();


        if (string.Equals(scene.name, "Cutscene1"))
        {
            SceneManager.LoadScene("Level1Alt");
        }
        else if (string.Equals(scene.name, "Cutscene2"))
        {
            SceneManager.LoadScene("Level2");
        }
        else if(scene.name == "Cutscene3")
        {
            SceneManager.LoadScene("AfterShow");
        }
        else if (scene.name == "Cutscene4") // lil pump boss battle
        {
            SceneManager.LoadScene("LevelLilPump");
        }
        else if (scene.name == "Cutscene5")
        {
            SceneManager.LoadScene("Level4");
        }
        else if (scene.name == "Cutscene6")
        {
            SceneManager.LoadScene("NextDay");
        }
        else if (scene.name == "Cutscene7")
        {
            SceneManager.LoadScene("Level5");
        }
        else if (scene.name == "Cutscene8") // lil yachty boss battle
        {
			SceneManager.LoadScene("LevelYachty");
        }
        else if (scene.name == "Cutscene9")
        {
            SceneManager.LoadScene("Cutscene10");
        }
        else if (scene.name == "Cutscene10")
        {
            SceneManager.LoadScene("Cutscene11");
        }
        else if (scene.name == "Cutscene11")
        {
            SceneManager.LoadScene("Level6");
        }
        else if (scene.name == "Cutscene12")
        {
            SceneManager.LoadScene("Level7");
        }
        else if (scene.name == "Cutscene13")
        {
            SceneManager.LoadScene("NextMorning");
        }
        else if (scene.name == "Cutscene14")
        {
            SceneManager.LoadScene("DrakeCutscene");
        }
        else if (scene.name == "DrakeCutscene")
        {
            SceneManager.LoadScene("LevelDrake");
        }
    }

}
