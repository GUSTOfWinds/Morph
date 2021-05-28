using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;
    public bool IsOnPatrol;

    public Transform[] moveSpots;
    private int randomSpot;
    private int stopCount;
    private int startCount;


    private void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        IsOnPatrol = true;
    }

    private void Update()
    {
        if(!IsOnPatrol)
        {
            // Ifall spelaren syns så slutar vakten att patrolera. 
            return;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
                

        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
                ChangeRotation();
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    // Patrol scripts.

    public void StopPatrol()
    {
        if (!IsOnPatrol)
        {
            return;
        }

        Debug.Log("Stopping patrol");
        
        IsOnPatrol = false;

        StartCoroutine(returnToPatrol());
    }

    public void StartPatrol()
    {
        Debug.Log("Starting patrol");
        
        IsOnPatrol = true;
    }

    IEnumerator returnToPatrol()
    {
        Debug.Log("Returning to patrol");

        //Wait for 5 seconds
        yield return new WaitForSeconds(5);

        StartPatrol();
    }
    

    public void ChangeRotation()
    {
        if (Vector3.Distance(moveSpots[1].position, transform.position) < 0.2)
        {
            gameObject.transform.LookAt(moveSpots[0]);
        }
         else if (Vector3.Distance(moveSpots[0].position, transform.position) < 0.2)
        { 
            gameObject.transform.LookAt(moveSpots[1]);
        }
               

    }

}