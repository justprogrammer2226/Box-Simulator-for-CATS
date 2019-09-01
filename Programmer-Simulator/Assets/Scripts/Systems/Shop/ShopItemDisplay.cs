using TMPro;
using UnityEngine;
using UnityEngine.UI;

class ShopItemDisplay : MonoBehaviour
{
    [SerializeField] private ShopItemData _shopItemData;
    public ShopItemData ShopItemData
    {
        get => _shopItemData;
        set
        {
            _shopItemData = value;
            UpdateUI();
        }
    }

    [SerializeField] private Image _itemImage;
    [SerializeField] private TextMeshProUGUI _itemValueText;

    [SerializeField] private Image _priceImage;
    [SerializeField] private TextMeshProUGUI _priceValueText;

    [SerializeField] private Button buyButton;

    private void Awake()
    {
        buyButton.onClick.AddListener(() => OnBuyButtonClick());
    }

    private void UpdateUI()
    {
        _itemImage.sprite = ShopItemData.ItemGameResource.GameResourceData.Sprite;
        _itemValueText.text = ShopItemData.ItemGameResource.Value.ToString();

        _priceImage.sprite = ShopItemData.PriceGameResource.GameResourceData.Sprite;
        _priceValueText.text = ShopItemData.PriceGameResource.Value.ToString();
    }

    private void OnBuyButtonClick()
    {
        if(ShopManager.instance.CanBuy(ShopItemData.ItemGameResource, ShopItemData.PriceGameResource))
        {
            ShopManager.instance.Buy(ShopItemData.ItemGameResource, ShopItemData.PriceGameResource);
        }
        else
        {
            Debug.Log("The buy failed. There is probably not enough money for the player, or the price or product is not the player’s game resources.");
        }
    }
}
