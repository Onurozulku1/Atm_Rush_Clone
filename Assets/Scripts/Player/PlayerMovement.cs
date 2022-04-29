using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    private Vector3 movementVector;
    Touch touch;

    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.deltaPosition.x == 0)
                return;

            movementVector = 0.05f * speed * (Vector3.forward + Vector3.right * Mathf.Sign(touch.deltaPosition.x));
            transform.Translate(movementVector);
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -GameManager.instance.groundBoundaries, GameManager.instance.groundBoundaries);
            transform.position = clampedPosition;

        }
        else
        {
            //pc
            movementVector = 0.05f * speed * (Vector3.forward + Vector3.right * Input.GetAxis("Horizontal"));
            transform.Translate(movementVector);
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -GameManager.instance.groundBoundaries, GameManager.instance.groundBoundaries);
            transform.position = clampedPosition;
        }
    }
}
