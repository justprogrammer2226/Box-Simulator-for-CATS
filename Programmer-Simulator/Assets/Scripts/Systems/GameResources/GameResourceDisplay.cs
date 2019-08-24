using TMPro;
using UnityEngine;
using UnityEngine.UI;

class GameResourceDisplay : MonoBehaviour
{
    public GameResource gameResource;

    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;

    public void UpdateUI()
    {
        image.sprite = GameResourceManager.GetSpriteByIndex(gameResource.GameResourceId);
        text.text = gameResource.Value.ToString();
    }
}
