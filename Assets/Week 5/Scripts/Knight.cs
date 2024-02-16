using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Knight : MonoBehaviour
{
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    Rigidbody2D rb;
    Animator animator;
    bool clickingOnSelf = false;
    public float health;
    public float maxHealth = 5;
    public Healthbar healthbar;
    public bool isdead;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //health = maxHealth;
        PlayerPrefs.GetFloat("RealHealth", 5);
        health = PlayerPrefs.GetFloat("RealHealth");
    }

    private void FixedUpdate()
    {
        if (isdead) return;

        movement = destination - (Vector2)transform.position;

        if(movement.magnitude < 0.1)
        {
            movement = Vector2.zero;


        }

        rb.MovePosition(rb.position +  movement.normalized * speed * Time.deltaTime);

    }


    // Update is called once per frame
    void Update()
    {

        SendMessage("startValue", PlayerPrefs.GetFloat("RealHealth"));
        if (isdead) return;

        


        if (Input.GetMouseButtonDown(0) && !clickingOnSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);



        }
        animator.SetFloat("Movement", movement.magnitude);

        if (Input.GetMouseButtonDown(1) && !clickingOnSelf && (health > 0))
        {
            animator.SetTrigger("Attack");
        }



    }

    private void OnMouseDown()
    {
        if (isdead) return;

        clickingOnSelf = true;
        SendMessage("TakeDamage", 1);
        //TakeDamage(1);
        //healthbar.TakeDamage(1);

    }

    private void OnMouseUp()
    {
        clickingOnSelf = false;

    }



    public void TakeDamage(float damage)
    {
        
        health -= damage;
        PlayerPrefs.SetFloat("RealHealth", health);

        health = Mathf.Clamp(health, 0, maxHealth);
        if (health == 0)
        {
            //if (isdead) return; //this code stops the knight from taking damage from weapon when dead and was tested but not enough to ensure that it doesn't mess other things up
            //die
            isdead = true;
            animator.SetTrigger("Death");

        }
        else
        {
            
            

            isdead = false;
            animator.SetTrigger("TakeDamage");

        }



    }

    public void UnTakeDamage()
    {
        PlayerPrefs.DeleteKey("RealHealth");

        health = 4; //heals four but knight is still dead
        SendMessage("TakeDamage", -1); //allows the knight to heal one (5 total) and revive from the dead state
        PlayerPrefs.SetFloat("RealHealth",health);
        
        
    
    }





}
