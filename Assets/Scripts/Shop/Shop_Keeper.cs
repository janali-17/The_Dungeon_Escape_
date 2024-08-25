using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Keeper : MonoBehaviour
{

    [SerializeField]
    private GameObject Shop;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                UI_Manager.Instance.OpenShop(player.Diamond);
            }
            Shop.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Shop.SetActive(false);
        }
    }
}
