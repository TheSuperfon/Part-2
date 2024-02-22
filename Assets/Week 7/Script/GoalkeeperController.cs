using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    public GameObject goalkeeper;
    Rigidbody2D GoalkeeperRigidbody;
    Vector2 goalkeeperdirection;
    public float goalLinedistance;
    // Start is called before the first frame update
    void Start()
    {
        GoalkeeperRigidbody = goalkeeper.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (TheController.SelectedPlayer == null) return;

        if (TheController.SelectedPlayer == null) return;
        goalkeeperdirection = ((Vector2)TheController.SelectedPlayer.transform.position - (Vector2)transform.position);
        goalLinedistance = goalkeeperdirection.magnitude;
        goalkeeperdirection.Normalize();
    }

    private void FixedUpdate()
    {
        if (TheController.SelectedPlayer == null) return;

        if (goalLinedistance < goalkeeperdirection.magnitude + 1) //when player enters the goal radius  
        {
            //Debug.Log("in");
            GoalkeeperRigidbody.position = Vector2.MoveTowards(GoalkeeperRigidbody.position,(Vector2)transform.position + goalkeeperdirection * goalLinedistance / 4, 0.2f); //half distance of the other one

        }
        else if (goalLinedistance > goalkeeperdirection.magnitude )//when player is not in the goal radius
        {
            GoalkeeperRigidbody.position = Vector2.MoveTowards(GoalkeeperRigidbody.position, (Vector2)transform.position + goalkeeperdirection * goalLinedistance / 2, 0.2f); //double distance of the other one (regular distance)

        }



    }


}
