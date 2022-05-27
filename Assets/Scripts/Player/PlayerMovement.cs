using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 30;
    private Vector3 movementVector;
    Touch touch;

    float posX;
    float posZ;

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
            GameManager.LevelEnding?.Invoke();
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

    private void OnEnable()
    {
        GameManager.LevelEnding += () => playable = false;
        GameManager.LevelEnding += () => transform.position = Vector3.forward * transform.position.z;
    }

    private void OnDisable()
    {
        GameManager.LevelEnding -= () => playable = false;
        GameManager.LevelEnding -= () => transform.position = Vector3.forward * transform.position.z;
    }
}
