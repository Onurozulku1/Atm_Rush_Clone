using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetScoreDisplay : MonoBehaviour
{
    [SerializeField] GameObject moneyObject;
    private GameObject[] moneyScores;

    private Transform player;
    private Animator playerAnim;
    private void Start()
    {
        player = WalletManager.instance.gameObject.transform;
        playerAnim = player.GetComponent<Animator>();
    }

    private void Update()
    {
        if (WalletManager.instance.wallet[0] == null)
            return;

        if (WalletManager.instance.wallet[0].transform.position.x < - GameManager.instance.groundBoundaries * 1.2f)
        {
            GameManager.instance.moneyMovement = false;
            foreach (GameObject item in WalletManager.instance.wallet)
            {
                Destroy(item);
            }
            player.Rotate(new Vector3(0, 180, 0));
            player.position = new Vector3(0, player.position.y, player.position.z + 40);
            

        }
    }

    private void OnEnable()
    {
        moneyScores = new GameObject[WalletManager.instance.storedMoney];
        for (int i = 0; i < WalletManager.instance.storedMoney; i++)
        {
            GameObject go;
            go = Instantiate(moneyObject, new Vector3(100, 100, 100), Quaternion.identity);
            go.name = "scoreMoney" + i;
        }
    }

    private void OnDisable()
    {
        
    }

    private void ScoreAnimation()
    {

    }
}
