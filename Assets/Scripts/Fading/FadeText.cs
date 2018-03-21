/* This entire script was written by Michael Lozada */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeText : MonoBehaviour
{
    private float restartDelay = 1f;

    private void Start()
    { 
        StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
    }

    void Update()
    {
        // when Return Key hit, intializes Coroutine to Fade text in
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(FadeTextToZeroAlpha(1f, GetComponent<Text>()));
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            Invoke("Restart", restartDelay);
        }
    }


    // Fade in text
    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    // Fade out text 
    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    // loads correct scene after transition scene is complete
    void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();


        if (string.Equals(scene.name, "AfterShow"))
        {
            SceneManager.LoadScene("Cutscene4");
        }
        else if (string.Equals(scene.name, "NextDay"))
        {
            SceneManager.LoadScene("Cutscene7");
        }
		else if (string.Equals(scene.name, "LaterThatDay"))
		{
			SceneManager.LoadScene("Cutscene12");
		}
		else if (string.Equals(scene.name, "NextMorning"))
		{
			SceneManager.LoadScene("Cutscene14");
		}
        else if (string.Equals(scene.name, "You Win"))
        {
            SceneManager.LoadScene("Menu(Main)");
        }
        else
        {
			SceneManager.LoadScene("Menu(inbetween)");
        }
    }
}