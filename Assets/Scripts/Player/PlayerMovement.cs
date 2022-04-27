using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    private Vector3 movementVector;
    private Collider groundCollider;
    private float groundBoundaries;

    private void Awake()
    {
        groundCollider = GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider>();
        groundBoundaries = groundCollider.bounds.extents.x * 0.8f;
    }

    private void FixedUpdate()
    {
        movementVector = (Vector3.forward + Vector3.right * Input.GetAxis("Horizontal")) * speed * 0.05f;
        transform.Translate(movementVector);
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -groundBoundaries, groundBoundaries);
        transform.position = clampedPosition;
    }
}
