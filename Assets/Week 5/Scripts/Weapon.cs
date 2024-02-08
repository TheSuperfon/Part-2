using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    float speed = 35;
    Rigidbody2D rb;
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);
        timer += Time.deltaTime;

        if (timer >= 5)
        {
            Destroy(gameObject);
        } 


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 2, SendMessageOptions.DontRequireReceiver);
        //Debug.Log("ok");
        if (collision.gameObject.name == ("Knight"))
        {
            Destroy(gameObject);


        }
        
    }



}
