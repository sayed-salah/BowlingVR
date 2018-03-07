using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class globalscript : MonoBehaviour {
    private float starttime;
    private float endTime;
    
    public AudioClip startSound;
    public AudioClip endclip;
    public AudioSource audio_source;
    private GameObject collisionArea;
    private bool palysound;
    public static bool endgame;
    private bool stopsound;
    public GameObject endshape;
   
    // Use this for initialization
    void Start () {
        starttime = 20f;
        endTime = 60f;
        palysound = false;
        endgame = true;
        stopsound = false;
        endshape.SetActive(false);
        collisionArea = GameObject.FindGameObjectWithTag("collision_area");
      
       

    }
    public void startGame()
    {
        endshape.SetActive(false);
        SceneManager.LoadScene("bowling");
    }
	// Update is called once per frame
	void Update () {

        if (!endgame)
        {
            endshape.SetActive(true);
        }

        starttime -= Time.deltaTime;

        if (starttime <= 0 && palysound== false)
        {
          
           
            talkManger.talking = false;
           if(!audio_source.isPlaying)
            {
                audio_source.PlayOneShot(startSound);
                palysound = true;
            }
           
           

        }
        else
        {
            endTime -= Time.deltaTime;
            if (endTime <= 0 && stopsound==false)
            {
                audio_source.PlayOneShot(endclip);
              //  collisionArea.GetComponent<pins_score>().enabled = false;
                stopsound = true;
                endgame = false;
            }
        }

	}
}
