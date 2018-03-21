/* This entire script was written by Michael Lozada */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dialogueActive = false;

    public string[] dialogLines;
    public int currentLine;

	// Use this for initialization
	void Start ()
    {
        dBox.SetActive(false);
        currentLine = 0;
        //fillDialogue();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // every time player presses enter, progresses onto next string
        if (dialogueActive && Input.GetKeyDown(KeyCode.Return))
        {
            currentLine++;
        }

        //once all text from array is read
        if(currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogueActive = false;

            // reset counter to start in future dialogue array
            currentLine = 0;
        }


        dText.text = dialogLines[currentLine];
	}

    // shows text box, called by other scripts
    public void ShowDialogue()
    {
        dialogueActive = true;
        dBox.SetActive(true);

    }
}
