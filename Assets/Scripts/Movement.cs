using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private Rigidbody playerRb;

    private void FixedUpdate()
    {
        float inputx = Input.GetAxis("Horizontal");
        float inputz = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.forward * inputz + transform.right * inputx) * movementSpeed * 100 * Time.deltaTime;
        playerRb.velocity = new(moveDirection.x, playerRb.velocity.y, moveDirection.z);
    }
}
