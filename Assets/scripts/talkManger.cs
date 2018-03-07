using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talkManger : MonoBehaviour
{
    public Text speaker;
    public Text text;
    public float timebetweendisplay;
    [TextArea]
    public string textToDisp;
    public GameObject talkgameobject;
    public static bool talking;
   // public GameObject camera;

    Coroutine coroutine;

    // Use this for initialization
    void Start()
    {
        talking = true;
        StartCoroutine(waitingtimetodispaly());
    }

    // Update is called once per frame
    void Update()
    {
        if (!talking)
        {
            Destroy(talkgameobject);
            Destroy(this);
        }

    }

    IEnumerator waitingtimetodispaly()
    {
        yield return new WaitForSeconds(6f);
        DisplayText(textToDisp, timebetweendisplay);
        while (true)
        {
            if (talking)
            {
                Debug.Log("at if condition");
                speaker.text = ":)";
                yield return new WaitForSeconds(.1f);
                speaker.text = ":O";
                yield return new WaitForSeconds(.1f);
                speaker.text = ":D";
            }
            else
            {
                Debug.Log("at else condition");
                speaker.text = ":)";
                yield return new WaitForSeconds(.2f);
               // gameObject.SetActive(false);
               //  this.enabled = false;
                yield return null;

            }
        }
    }
    public void DisplayText(string textToDisplay, float timeBetweenLetters)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(DisplayTextCoro(textToDisp, timeBetweenLetters));
    }

    IEnumerator DisplayTextCoro(string textToDisplay, float timeInSeconds)
    {
        talking = true;
        text.text = "";
        foreach (var letter in textToDisplay)
        {

            text.text += letter;
            yield return new WaitForSeconds(timeInSeconds);
        }
        talking = false;
    }
}
