using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    private Vector3 movementVector;

    private void Update()
    {
    }
    private void FixedUpdate()
    {
        movementVector = (Vector3.forward + Vector3.right * Input.GetAxis("Horizontal")) * speed * Time.deltaTime;
        transform.Translate(movementVector);
        
    }
}
