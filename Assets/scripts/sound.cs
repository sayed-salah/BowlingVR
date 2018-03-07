using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour {
   // public AudioClip hit_floorclip;
    public AudioClip floorclip;
    public AudioClip pinsclip;
    private AudioSource audio_source;


	// Use this for initialization
	void Start () {
        audio_source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
      
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            // audio.clip = flo
            audio_source.PlayOneShot(floorclip);

        }
        else if (collision.gameObject.tag == "pins")
        {
            audio_source.PlayOneShot(pinsclip);
        }
        
    }

}
