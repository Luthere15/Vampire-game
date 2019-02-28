using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceAttack : MonoBehaviour {
    public GameObject ice;
    GameObject iceclone;
    float IceTimer ;
    
	// Use this for initialization
	void Start () {

        iceclone = Instantiate(ice)as gameObject;
	}
    void FixedUpdate()
    {
       
    }

    // Update is called once per frame
    void Update ()
    {
        IceTimer = Time.deltaTime; 
		if(IceTimer==3)
        {
            Instantiate(ice);

        }
	}
}
