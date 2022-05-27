using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static Action LevelEnding;

    private AssetScoreDisplay aSDisplay;

    private Collider groundCollider;
    public float groundBoundaries;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;

        aSDisplay = GetComponent<AssetScoreDisplay>();

        groundCollider = GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider>();
        groundBoundaries = groundCollider.bounds.extents.x * 0.8f;
    }

    private void OnEnable()
    {
        LevelEnding += () => aSDisplay.enabled = true;
    }

    private void OnDisable()
    {
        LevelEnding -= () => aSDisplay.enabled = true;
    }

    private void OnDestroy()
    {
        LevelEnding = null;
    }
}
