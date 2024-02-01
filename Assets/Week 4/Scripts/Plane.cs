using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public List<Sprite> PlaneSprites;
    public int SpriteChoice;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    Vector2 currentPosition;
    public float speed;
    public AnimationCurve landing;
    float timerValue;
    float Dangerzone = 1; //top gun referance


    float planedistance;
    

    

    private void Start()
    {
        //spriteRenderer.color = Color.white;

        lineRenderer = GetComponent<LineRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0,transform.position);
        Vector2 StartPosition = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);

        transform.position = StartPosition;
        //float random = 
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0,360));

        speed = Random.Range(1, 3);

        SpriteChoice = Random.Range(0, 3);
        spriteRenderer.sprite = PlaneSprites[SpriteChoice];


    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if (points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }
        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);



    }

    private void Update()
    {
        if (transform.position.y >= 5.3 || transform.position.y <= -5.3 || transform.position.x <= -10 || transform.position.x >= 10)
        {
            Destroy(gameObject);

        }



        if(Input.GetKey(KeyCode.Space)) 
        {
            timerValue += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(timerValue);

            
            if(transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);

            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);

        }




        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0)
        {
            if (Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for(int i = 0; i < lineRenderer.positionCount - 2; i ++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                    

                }
                lineRenderer.positionCount--;

            }
        }

        
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }
    private void OnMouseDrag() 
    { 
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(lastPosition, newPosition) > newPointThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount -1, newPosition);
            lastPosition = newPosition;

        }
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        spriteRenderer.color = Color.red;
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        planedistance = Vector3.Distance(collision.attachedRigidbody.position, transform.position);

        if (planedistance < Dangerzone)
        {
            Destroy(gameObject);
        }

        //Debug.Log(planedistance);
    }


}
