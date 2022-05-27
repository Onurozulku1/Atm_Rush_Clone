using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static Action LevelEnding;


    private Collider groundCollider;
    public float groundBoundaries;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;

        groundCollider = GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider>();
        groundBoundaries = groundCollider.bounds.extents.x * 0.8f;
    }

    private void OnDestroy()
    {
        LevelEnding = null;
    }
}
