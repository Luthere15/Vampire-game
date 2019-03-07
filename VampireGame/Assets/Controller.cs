using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    private Vector2 movement;
    public float speed ;
    public float jumpForce;
    public float showDamageDuration= 100f;
    public bool showingDamage = false;
    public float damageDoneTime= 5f;

    public bool isjumping;
    
    private Rigidbody2D rb;

    private SpriteRenderer damage;
    private Rigidbody2D freeze;

    Rigidbody2D constraints;



    // Use this for initialization
    void Start () {
        
        rb = GetComponent<Rigidbody2D>();

        damage = GetComponent<SpriteRenderer>();

        constraints = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal")*speed;
        //float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb.AddForce(movement);
        //constraints.constraints = RigidbodyConstraints2D.None;

        jump();
    }

    // Update is called once per frame
    void Update () {
        // constraints.constraints = RigidbodyConstraints2D.FreezePositionX;
        if (showingDamage == true && Time.time > damageDoneTime)
        {
            unShowDamage();
        }

    }

    void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& !isjumping)
        {
            isjumping = true;

            rb.AddForce(new Vector2(movement.x, jumpForce));
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Ground"))
        {
            isjumping = false;

            
        }


        if (other.gameObject.tag == "fissure")
        {
            //float counter = 5; 
            showingDamage = true; 
            damage.color = new Color();
            damage.color = Color.red;
            constraints.velocity = Vector2.zero;
            damageDoneTime = Time.time + showDamageDuration;



        }

       
       

    }
    void unShowDamage()
    {
        damage.color = Color.white;
       
    }

    
}
