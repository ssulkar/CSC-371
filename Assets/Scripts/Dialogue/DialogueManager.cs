using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dialogueActive;

    public string[] dialogLines;
    public int currentLine;

	// Use this for initialization
	void Start ()
    {
        currentLine = 0;
        dialogLines = new string[3];
        fillDialogue();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // every time player presses space, progresses onto next string
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
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

    public void fillDialogue()
    {
        dialogLines[0] = "STRAIGHT UP";
        dialogLines[1] = "LA FLAME!";
        dialogLines[2] = "MOM: STOP MAKING LISTENING TO THAT HIPPITY HOP GARBAGE!";
    }
}
