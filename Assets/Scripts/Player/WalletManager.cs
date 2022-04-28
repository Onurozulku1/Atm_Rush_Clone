using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletManager : MonoBehaviour
{
    public List<GameObject> wallet;
   
    [Range(1,10)] public float moneySpacing = 2f;

    public static WalletManager instance;
    private void Awake()
    {
        instance = this;
        wallet = new List<GameObject>();
    }

    private void FixedUpdate()
    {
        MoveMoneys();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable") && !collision.gameObject.GetComponent<Collectable>().isCollected)
        {
            wallet.Add(collision.gameObject);
            collision.gameObject.GetComponent<Collectable>().isCollected = true;
        }
    }

    private void MoveMoneys()
    {
        
    }

}
