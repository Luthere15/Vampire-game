using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brute : MonoBehaviour {

    public GameObject fissure;
    public float fissureSpeed = 40; 
    public float speed = 1f;
    public float leftAndRightEdge = 1f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenFissureattack = 5f;
    public static float leftScreen  = -10f;
    

	// Use this for initialization
	void Start () {

        Invoke("tempFire", 2f);
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

       
        if (transform.position.x < leftScreen)
        {
            Destroy(this.gameObject);
        }
    }

    void tempFire()
    {
        GameObject attack = Instantiate<GameObject>(fissure);
        attack.transform.position = new Vector2(transform.position.x,-1);
        

        Rigidbody2D rigidB = attack.GetComponent<Rigidbody2D>();
        //rigidB.transform.position = new Vector2(0, -1);
        rigidB.velocity = Vector2.left * fissureSpeed;

        Invoke("tempFire", secondsBetweenFissureattack);
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
      
       

        
        if (coll.gameObject.tag == "Player"  )
        {
            // Destroy(coll.gameObject);
           
            
           // Destroy(fissure.gameObject);

            return;
        }

       
        
    }
}
