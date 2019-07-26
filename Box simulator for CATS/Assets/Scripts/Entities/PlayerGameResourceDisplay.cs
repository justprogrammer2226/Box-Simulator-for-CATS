using TMPro;
using UnityEngine;
using UnityEngine.UI;

class PlayerGameResourceDisplay : MonoBehaviour
{
    public PlayerGameResource playerGameResource;

    public TextMeshProUGUI value;
    public Image image;

    private void Start()
    {
        InitUpdateUI();
    }

    public void InitUpdateUI()
    {
        value.GetComponent<SmoothChangingOfNumber>().SetInitValues((ulong)playerGameResource.Value, (ulong)playerGameResource.Value);
        image.sprite = playerGameResource.GameResource.Sprite;
    }

    public void UpdateUI()
    {
        value.text = playerGameResource.Value.ToString();
        image.sprite = playerGameResource.GameResource.Sprite;
    }
}
