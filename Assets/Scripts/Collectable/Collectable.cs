using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int stage = 0;
    public bool isCollected = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable") && !collision.gameObject.GetComponent<Collectable>().isCollected)
        {
            if (collision.transform.position.z >= transform.position.z)
            {
                WalletManager.instance.wallet.Add(collision.gameObject);
                collision.gameObject.GetComponent<Collectable>().isCollected = true;
            }
            
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle") && isCollected)
        {
            WalletManager.instance.SpreadMoney(this);
        }

        if (other.gameObject.CompareTag("Upgrader") && isCollected)
        {
            UpgradeStage();
        }

        if (other.gameObject.CompareTag("Bank") && isCollected)
        {
            WalletManager.instance.Deposit(this);
        }
    }


    private void UpgradeStage()
    {
        if (stage < WalletManager.instance.stageMaterials.Length)
        {
            stage++;
            GetComponent<MeshRenderer>().material = WalletManager.instance.stageMaterials[stage - 1];
        }
    }
}
