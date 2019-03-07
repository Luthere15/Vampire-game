using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brute : MonoBehaviour {

    public GameObject fissure;
    public float fissureSpeed = 40; 
    public float speed = 1f;
    public float leftAndRightEdge = 1f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenFissureattack = 1f;
    

	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if(pos.x< -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }else if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }

        if (Input.GetKeyDown(KeyCode.A))

        {
            tempFire();
        }

       

    }

    void tempFire()
    {
        GameObject attack = Instantiate<GameObject>(fissure);
        attack.transform.position = this.transform.position;
        

        Rigidbody2D rigidB = attack.GetComponent<Rigidbody2D>();
        //rigidB.transform.position = new Vector2(0, -1);
        rigidB.velocity = Vector2.left * fissureSpeed;

        
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("collided with : " + coll.gameObject);
        int hit=0;

        
        if (coll.gameObject.tag == "Player"&& hit== 3)
        {
            // Destroy(coll.gameObject);
           
            
            Destroy(this.gameObject);

            return;
        }
        hit++;
    }
}
