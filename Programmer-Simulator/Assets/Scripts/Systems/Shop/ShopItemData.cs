using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item Data", menuName = "Shop Item Data")]
public class ShopItemData : ScriptableObject
{
    [SerializeField] private GameResource _itemGameResource;
    public GameResource ItemGameResource => _itemGameResource;

    [SerializeField] private GameResource _priceGameResource;
    public GameResource PriceGameResource => _priceGameResource;
}