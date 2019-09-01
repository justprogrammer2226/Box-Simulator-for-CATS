using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Shop
{
    [SerializeField] private string _title;
    public string Title => _title;

    [SerializeField] private List<ShopItemData> _items;
    public List<ShopItemData> Items => _items;
}