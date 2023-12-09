using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviours : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] Rigidbody rb;

    [SerializeField] int seekIndex;
    [SerializeField] int fleeIndex;

    [SerializeField] float followSpeed;
    [SerializeField] float repulseSpeed;

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
            Vector3 attract = (player.transform.position - transform.position).normalized;
            rb.velocity = attract * followSpeed;
        }
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
        if (isFleeing)
        {
            Vector3 attract = (transform.position - player.transform.position).normalized;
            rb.velocity = attract * repulseSpeed;
        }
    }

    private void Update()
    {
        Seeking();
        Fleeing();
    }
}
