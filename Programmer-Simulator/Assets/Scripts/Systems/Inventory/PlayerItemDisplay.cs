using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItemDisplay : MonoBehaviour
{
    public PlayerItemData playerItem;

    public Image image;

    public void UpdateUI()
    {
        image.sprite = playerItem.Sprite;
    }
}
