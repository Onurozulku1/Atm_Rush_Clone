using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 playerGap;
    Transform player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Start()
    {
        playerGap = transform.position - player.position;
    }

    private void Update()
    {
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + playerGap, 0.2f);
    }

    private void OnEnable()
    {
        GameManager.LevelEnding += () => playerGap += new Vector3(0, 4, -16);
    }

    private void OnDisable()
    {
        GameManager.LevelEnding -= () => playerGap += new Vector3(0, 4, -16);
    }
}
