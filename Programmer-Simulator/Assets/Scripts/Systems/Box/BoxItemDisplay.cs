using UnityEngine;
using UnityEngine.UI;

public class BoxItemDisplay : MonoBehaviour
{
    public BoxItemData playerItem;

    public Image image;

    public void UpdateUI()
    {
        image.sprite = playerItem.Sprite;
    }
}
