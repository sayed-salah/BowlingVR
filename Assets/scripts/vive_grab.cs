using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vive_grab : MonoBehaviour {

    public ViveHand hand;
    private Rigidbody grabedbody;
    private AudioClip audio;
   // public GameObject prefabinstition;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (grabedbody == null)
        {
            if (ViveInput.GetButtonDown(hand, ViveButton.Trigger))
            {
                RaycastHit hit;
                Collider[] colider = Physics.OverlapSphere(ViveInput.GetPosition(hand), 0.09f);
                if (colider.Length > 0)
                {
                    grabedbody = colider[0].GetComponent<Rigidbody>();

                    grabedbody.useGravity = false;
                    grabedbody.isKinematic = true;
                        }

                if (Physics.Raycast(ViveInput.GetPosition(hand), ViveInput.GetTransform(hand).forward, out hit))
                {

                    Debug.Log("here at raycast");
                    if (hit.rigidbody.gameObject.tag == "bowling_ball")
                    {
                        //var bullet= Instantiate(prefabinstition);
                     //   bullet.transform.position = hit.rigidbody.transform.position;
                       
                        Debug.Log("here with ball");
                        grabedbody = hit.rigidbody;
                        grabedbody.useGravity = false;
                        grabedbody.isKinematic = true;
                    }
                   // Destroy(prefabinstition);
                    

                }

            }
            

        }
        else
        {
            grabedbody.transform.position = ViveInput.GetPosition(hand);
            grabedbody.transform.rotation = ViveInput.GetRotation(hand);

            if (ViveInput.GetButtonUp(hand, ViveButton.Trigger))
            {
                grabedbody.angularVelocity = ViveInput.GetAngularVelocity(hand);
                grabedbody.velocity = ViveInput.GetVelocity(hand);
                grabedbody.isKinematic = false;
                grabedbody.useGravity = true;
                grabedbody = null;
            }
        }

   





    }

}
