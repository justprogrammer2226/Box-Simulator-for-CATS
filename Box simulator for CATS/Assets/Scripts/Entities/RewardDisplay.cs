using TMPro;
using UnityEngine;
using UnityEngine.UI;

class RewardDisplay : MonoBehaviour
{
    public Reward reward;

    public TextMeshProUGUI value;
    public Image image;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        value.text = reward.Value.ToString();
        image.sprite = reward.GameResource.Sprite;
    }
}
