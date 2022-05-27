using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetScoreDisplay : MonoBehaviour
{
    private GameObject[] moneyScores;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (WalletManager.instance.wallet[0].transform.position.x < - GameManager.instance.groundBoundaries * 1.2f)
        {
            
        }
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
