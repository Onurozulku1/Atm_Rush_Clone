using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Collider groundCollider;
    public float groundBoundaries;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;

        groundCollider = GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider>();
        groundBoundaries = groundCollider.bounds.extents.x * 0.8f;
    }
}
