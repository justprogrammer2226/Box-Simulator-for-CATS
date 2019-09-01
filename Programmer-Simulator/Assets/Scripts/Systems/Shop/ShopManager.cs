using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public GameObject shopBlockPrefab;
    public GameObject shopItemPrefab;
    public GameObject shopsPanel;
    public List<Shop> shops;
    public GameObject shopMenu;

    public Player player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            throw new Exception("The instance of the shop manager already exists.");
        }
    }

    private void Start()
    {
        // Temporary activation of the menu is needed for a normal rebuild.
        bool isShopMenuActive = shopMenu.activeInHierarchy;
        shopMenu.SetActive(true);
        foreach (Shop shop in shops)
        {
            ShopBlock shopBlock = Instantiate(shopBlockPrefab, shopsPanel.transform).GetComponent<ShopBlock>();
            shopBlock.Title = shop.Title;

            foreach(ShopItemData shopItemData in shop.Items)
            {
                ShopItemDisplay newShopItemDisplay = Instantiate(shopItemPrefab, shopBlock.ShopItemsPanel.transform).GetComponent<ShopItemDisplay>();
                newShopItemDisplay.ShopItemData = shopItemData;
            }
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(shopsPanel.GetComponent<RectTransform>());
        shopMenu.SetActive(isShopMenuActive);
    }

    private void SetDirty()
    {
        throw new NotImplementedException();
    }

    public void Buy(GameResource item, GameResource price)
    {
        if(CanBuy(item, price))
        {
            price.Value = -price.Value;
            player.AdjustPlayerGameResource(item);
            player.AdjustPlayerGameResource(price);
            price.Value = Mathf.Abs(price.Value);
        }
        else
        {
            throw new System.Exception("The buy failed. There is probably not enough money for the player, or the price or product is not the player’s game resources.");
        }
    }

    public bool CanBuy(GameResource item, GameResource price)
    {
        if (player.IsPlayerGameResource(item) && player.IsPlayerGameResource(price))
        {
            if (player.GetValueOfPlayerGameResource(price) >= price.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
