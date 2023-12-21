using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SteeringBehaviours : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] Rigidbody rb;

    [SerializeField] int seekIndex;
    [SerializeField] int fleeIndex;

    [SerializeField] float followSpeed;
    [SerializeField] float repulseSpeed;
    [SerializeField] float detectionRange;

    [SerializeField] bool isSeeking;
    [SerializeField] bool isFleeing;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    //SEEK Steering Behaviour
    public void SeekOn()
    {
        isSeeking = true;
        seekIndex++;
    }
    public void SeekOff()
    {
        if (seekIndex % 2 == 0)
        {
            isSeeking = false;
        }
    }
    void Seeking()
    {
        if (isSeeking)
        {
            Debug.Log("Seeking");
            Vector3 desiredVelocity = (player.transform.position - transform.position).normalized * followSpeed;
            Vector3 steeringForce = desiredVelocity - rb.velocity;
            rb.AddForce(steeringForce);
        }

        else
            rb.velocity = Vector3.zero;
    }

    //FLEE Steering Behaviour
    public void FleeOn()
    {
        isFleeing = true;
        fleeIndex++;
    }
    public void FleeOff()
    {
        if(fleeIndex % 2 == 0)
        {
            isFleeing= false;
        }
    }
    void Fleeing()
    {
        float distance = transform.position.magnitude - player.transform.position.magnitude;
        Debug.Log(distance);

        if (isFleeing)
        {
            Vector3 desiredVelocity = (transform.position - player.transform.position).normalized * repulseSpeed;
            Vector3 steeringForce = desiredVelocity - rb.velocity;
            rb.AddForce(steeringForce);
        }
    }

    private void Update()
    {
        Seeking();
        Fleeing();
    }
}
