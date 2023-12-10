using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Boids : MonoBehaviour
{
    [SerializeField] List<Boids> boids;

    [SerializeField] float boidMoveSpeed;

    Vector3 direction;
    void MoveBoids()
    {
        transform.Translate(direction * boidMoveSpeed * Time.deltaTime );
    }
    private void Update()
    {
        MoveBoids();
    }

}
