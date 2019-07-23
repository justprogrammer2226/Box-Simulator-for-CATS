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
        title.text = achievement.Title;
        reward.text = achievement.Reward.ToString();
        progress.text = $"{achievement.CurrentValue}/{achievement.TargetValue}";
        slider.value = (float) achievement.CurrentValue / achievement.TargetValue;
        rewardButtonText.text = "Get Reward";

        if (achievement.CurrentValue == achievement.TargetValue)
        {
            if(achievement.IsClaimed)
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
        if(!achievement.IsClaimed)
        {
            rewardButtonText.text = "Claimed";
            rewardButton.interactable = false;
            achievement.IsClaimed = true;
        }
    }
}
