using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pins_score : MonoBehaviour
{
    //public int[] pins;
    private static int score;
    private Text infoText;
    private Text timeText;
    private float varr;
    // Use this for initialization

    void Start()
    {
        score = 0;
        varr = 0;
        // timeText.text = "Time:- "+varr;
        infoText = GameObject.FindGameObjectWithTag("score_text").GetComponent<Text>();
        timeText = GameObject.FindGameObjectWithTag("time_text").GetComponent<Text>();






    }

    // Update is called once per frame
    void Update()
    {
        varr += Time.deltaTime;
        if (varr >= 60)
            varr = 60;
        var someString = string.Format("{0:0}:{1:00}", Mathf.Floor((60 - varr) / 60), (60 - varr) % 60);
        timeText.text = "Time:- " + someString;
        infoText.text = "Score:- " + score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (globalscript.endgame)
        {
            if (other.gameObject.tag == "Floor")
            {

                Debug.Log("firstenter");
                score += 1;
                Debug.Log("imhere");
                infoText.text = "Score:- " + score.ToString();
                Debug.Log("secondenter");
                GetComponent<Collider>().enabled = false;
                this.enabled = false;


            }
        }

    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "pins" )
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
