using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveforendgame : MonoBehaviour
{

    Transform c;
    // Use this for initialization
    void Start()
    {
        c = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.name);
        if (!c)
            c = Camera.main.transform;

        this.transform.position = c.position + c.forward * 1.6f;
        this.transform.forward = c.forward;
    }
}
