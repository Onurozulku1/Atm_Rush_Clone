using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMovement : MonoBehaviour
{
    private Collectable collectable;

    private float posX;
    private float posZ;
    private int objIndex;

    private void Awake()
    {
        if (GetComponent<Collectable>() != null)
            collectable = GetComponent<Collectable>();

    }

    private void FixedUpdate()
    {
        if (!collectable.isCollected)
            return;

        MoveCollectable();
    }

    private void MoveCollectable()
    {
        objIndex = WalletManager.instance.wallet.IndexOf(gameObject) + 1;

        if (WalletManager.instance.wallet.Contains(gameObject))
        {
            posX = Mathf.Lerp(posX, WalletManager.instance.transform.position.x, 0.1f + (0.1f / Mathf.Pow(objIndex, 4)));

            posZ = WalletManager.instance.transform.position.z + (WalletManager.instance.moneySpacing * (1 + objIndex));
        }

        transform.position = new Vector3(posX, transform.position.y, posZ);
    }
}
