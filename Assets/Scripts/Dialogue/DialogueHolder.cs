using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder: MonoBehaviour {

    public string[] dialogue;

    private DialogueManager dMan;
    
    // Use this for initialization
	void Start ()
    {
        dMan = FindObjectOfType<DialogueManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(name == "Sign1")
        {
            fillDialogue(1);
        }
        else if (name == "Sign2")
        {
            fillDialogue(2);
        }
        else if (name == "Sign3")
        {
            fillDialogue(3);
        }
        else if (name == "Sign4")
        {
            fillDialogue(4);
        }
        else if (name == "Sign5")
        {
            fillDialogue(5);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                if (!dMan.dialogueActive)
                {
                    dMan.dialogLines = dialogue;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                }
            }
        }
    }

    public void fillDialogue(int sign)
    {
        if(sign == 1)
        {
            dialogue[0] = "Use  WASD  to  move  and  jump";
        }
        else if(sign == 2)
        {
            dialogue[0] = "Use  SPACE  to  shoot  your  fire  mixtape!";
        }
        else if(sign == 3)
        {
            dialogue[0] = "Collect  clout  tokens  to  build  your  clout  and  level  up!";
        }
        else if (sign == 4)
        {
            dialogue[0] = "Collect  money  to  purchase  power  ups!";
        }
        else if (sign == 5)
        {
            dialogue[0] = "Collect  hidden  albums  to  discover  new  bangers!";
        }
        
    }
}
