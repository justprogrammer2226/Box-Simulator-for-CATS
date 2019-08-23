using TMPro;
using UnityEngine;
using UnityEngine.UI;

class GameResourceDisplay : MonoBehaviour
{
    public GameResourceData gameResource;

    public Image image;

    public void UpdateUI()
    {
        image.sprite = gameResource.Sprite;
    }
}
