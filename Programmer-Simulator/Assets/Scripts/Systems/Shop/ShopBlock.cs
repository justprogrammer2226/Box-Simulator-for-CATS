using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopBlock : MonoBehaviour
{
    [SerializeField] private GameObject _shopItemsPanel;
    public GameObject ShopItemsPanel => _shopItemsPanel;

    [SerializeField] private TextMeshProUGUI _titleText;
    public string Title
    {
        get => _titleText.text;
        set
        {
            _titleText.text = value;
        }
    }
}