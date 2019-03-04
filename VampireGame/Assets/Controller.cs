using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    private Vector3 movement;
    public float speed ;
    public float jumpForce;

    bool isjumping;
    
    private Rigidbody2D rb;
    

    // Use this for initialization
    void Start () {
        
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal")*speed;
        //float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb.AddForce(movement);

        jump();
    }

    // Update is called once per frame
    void Update () {

        //movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        //movement = transform.TransformDirection(movement);
        //movement *= speed;

    }

    void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& !isjumping)
        {
            isjumping = true;

            rb.AddForce(new Vector2(movement.x, jumpForce));
        }
    }

    void OnCollision2DEnter(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isjumping = false;

            //rb.AddForce(new Vector2(0, 0));
        }
        //GameObject collidedWith = other.gameObject;


        if(other.gameObject.tag=="fissure")
        {
            Destroy(other.gameObject);
        }
    }
}
