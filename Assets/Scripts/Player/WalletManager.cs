using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletManager : MonoBehaviour
{
    public List<GameObject> wallet;

    public Material[] stageMaterials;
   
    [Range(1,10)] public float moneySpacing = 2f;

    [HideInInspector] public int storedMoney = 0;

    public static WalletManager instance;
    private void Awake()
    {
        instance = this;
        wallet = new List<GameObject>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable") && !collision.gameObject.GetComponent<Collectable>().isCollected)
        {
            wallet.Add(collision.gameObject);
            collision.gameObject.GetComponent<Collectable>().isCollected = true;
        }
    }

    float spreadCenter;
    Vector3 spreadPos;
    public void SpreadMoney(Collectable collectable)
    {
        GameObject go = collectable.gameObject;
        spreadCenter = go.transform.position.z + 15;

        for (int i = wallet.IndexOf(go); i < wallet.Count; i++)
        {
            spreadPos = GameManager.instance.groundBoundaries * Random.insideUnitSphere;
            spreadPos.y = go.transform.position.y;
            wallet[i].transform.position = spreadPos + Vector3.forward * spreadCenter;
            wallet[i].GetComponent<Collectable>().isCollected = false;
            wallet.Remove(wallet[i]);
        }

    }

    public void Deposit(Collectable collectable)
    {
        GameObject go = collectable.gameObject;

        for (int i = wallet.IndexOf(go); i < wallet.Count; i++)
        {
            storedMoney += wallet[i].GetComponent<Collectable>().stage + 1;
            Destroy(wallet[i]);
            wallet.Remove(wallet[i]);

        }

    }

}
