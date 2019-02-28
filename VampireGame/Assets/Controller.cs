using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    private Vector3 movement;
    public int speed = 0;
    
    private Rigidbody2D rb;
    

    // Use this for initialization
    void Start () {
        
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement);
    }

    // Update is called once per frame
    void Update () {

        //movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        //movement = transform.TransformDirection(movement);
        //movement *= speed;

    }
}
