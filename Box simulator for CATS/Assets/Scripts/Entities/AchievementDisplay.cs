using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementDisplay : MonoBehaviour
{
    public Achievement achievement;

    public TextMeshProUGUI title;
    public TextMeshProUGUI reward;
    public TextMeshProUGUI progress;
    public Slider slider;
    public Button rewardButton;
    public TextMeshProUGUI rewardButtonText;

    private void Start()
    {
        rewardButton.onClick.AddListener(() => OnRewardButtonClick());
        UpdateUI();
    }

    public void UpdateUI()
    {
        title.text = achievement.title;
        reward.text = achievement.reward.ToString();
        progress.text = $"{achievement.currentValue}/{achievement.targetValue}";
        slider.value = (float) achievement.currentValue / achievement.targetValue;
        rewardButtonText.text = "Get Reward";

        if (achievement.currentValue == achievement.targetValue)
        {
            if(achievement.isClaimed)
            {
                rewardButtonText.text = "Claimed";
                rewardButton.interactable = false;
            }
            else
            {
                rewardButton.interactable = true;
            }
        }
    }

    private void OnRewardButtonClick()
    {
        if(!achievement.isClaimed)
        {
            rewardButtonText.text = "Claimed";
            rewardButton.interactable = false;
            achievement.isClaimed = true;
        }
    }
}
