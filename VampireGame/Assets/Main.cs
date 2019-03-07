using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    public float enemyspawnpersecond = 0.5f;
    public float enemyDefalutPadding = 1.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("spawnEnemy", 1f / enemyspawnpersecond);
	}


   
}
