using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Keeper : MonoBehaviour
{
    // Handles
    [SerializeField]
    private GameObject Shop;
    private Player _player;
    // Variables
    [SerializeField]
    private int _currentItem;
    [SerializeField]
    private int _costItem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _player = other.GetComponent<Player>();
            if(_player != null)
            {
                UI_Manager.Instance.OpenShop(_player.Diamond);
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
    public void Selection(int item)
    {
        _currentItem = item;
       switch (item)
        {
            case 0: // Flame Sword
                UI_Manager.Instance.UpdateSelectionShop(118);
                // _currentItem = 0;
                _costItem = 200;
                break;
            case 1:// Flight Boots
                UI_Manager.Instance.UpdateSelectionShop(7);
                // _currentItem = 1;
                _costItem = 400;
                break;
            case 2:// Key
                UI_Manager.Instance.UpdateSelectionShop(-109);
                //_currentItem = 2;
                _costItem = 100;
                break;
        }
    }
    public void BuyItem()
    {
        
        if(_player.Diamond >= _costItem)
        {
            if(_currentItem == 2)
            {
                GameManager.Instance.HasKey = true;
            }
            _player.Diamond -= _costItem;
            Debug.Log("U have purchased :" + _currentItem);
            Debug.Log("Remaining Diamonds :" + _player.Diamond);
            Shop.SetActive(false);
        }
        else
        {
            Debug.Log("You do not have enough Gems");
            Shop.SetActive(false);
        }
    }
}
