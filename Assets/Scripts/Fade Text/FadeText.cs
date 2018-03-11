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
        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(FadeTextToZeroAlpha(1f, GetComponent<Text>()));
        }

        if (Input.GetButtonUp("Jump"))
        {
            Invoke("Restart", restartDelay);
        }
    }



    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("Cutscene4");
    }
}