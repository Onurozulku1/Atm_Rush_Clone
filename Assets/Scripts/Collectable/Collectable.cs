using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Range(0, 1)] public int stage;
    public bool isCollected = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable") && !collision.gameObject.GetComponent<Collectable>().isCollected)
        {
            WalletManager.instance.wallet.Add(collision.gameObject);
            collision.gameObject.GetComponent<Collectable>().isCollected = true;
        }
    }
}
