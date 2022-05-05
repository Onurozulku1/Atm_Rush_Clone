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

        if (collectable.gameEnding)
            return;

        MoveCollectable();
    }

    private void MoveCollectable()
    {
        objIndex = WalletManager.instance.wallet.IndexOf(gameObject) + 1;
        Transform leadObject;
        if (objIndex > 1)
        {
            leadObject = WalletManager.instance.wallet[objIndex - 2].transform;
        }
        else
        {
            leadObject = WalletManager.instance.transform;
        }

        if (WalletManager.instance.wallet.Contains(gameObject))
        {
            posX = Mathf.Lerp(posX, leadObject.position.x, 0.5f);

            posZ = WalletManager.instance.transform.position.z + (WalletManager.instance.moneySpacing * (1 + objIndex));
        }

        transform.position = new Vector3(posX, transform.position.y, posZ);
    }
}
