using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_raycast : MonoBehaviour {
    public ViveHand hand;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
            if  (  Physics.Raycast(ViveInput.GetPosition(hand),ViveInput.GetTransform(hand).forward, out hit))
        {
            hit.rigidbody.gameObject.transform.position= ViveInput.GetPosition(hand);

            hit.rigidbody.gameObject.transform.rotation = ViveInput.GetRotation(hand);
        }
        

        
	}
}
