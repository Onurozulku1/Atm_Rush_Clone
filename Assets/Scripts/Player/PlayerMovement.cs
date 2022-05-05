using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2;
    private Vector3 movementVector;
    Touch touch;

    float posX;
    float posZ;
    Vector3 movement;

    Vector3 moveX;
    Vector3 moveZ;

    bool playable = true;

    private void FixedUpdate()
    {
        if (!playable)
            return;

        PlayerInput();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            playable = false;
        }
    }

    private void PlayerInput()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                posX = touch.deltaPosition.x * Time.deltaTime * 2;
            }
            else
                posX = 0;

            posZ = speed * Time.deltaTime;
            transform.position += new Vector3(posX, 0, posZ);
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -GameManager.instance.groundBoundaries, GameManager.instance.groundBoundaries);
            transform.position = clampedPosition;
        }
        else
        {
            //pc
            movementVector = Time.deltaTime * speed * (Vector3.forward + Vector3.right * Input.GetAxis("Horizontal"));
            transform.Translate(movementVector);
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -GameManager.instance.groundBoundaries, GameManager.instance.groundBoundaries);
            transform.position = clampedPosition;
        }
    }
}
