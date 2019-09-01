using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementDisplay : MonoBehaviour
{
    public Achievement achievement;

    public TextMeshProUGUI title;
    public TextMeshProUGUI progress;
    public Slider slider;
    public Button rewardButton;
    public TextMeshProUGUI rewardButtonText;
    public GameObject rewardPrefab;
    public GameObject rewardsPanel;

    private void Awake()
    {
        rewardButton.onClick.AddListener(() => OnRewardButtonClick());
    }

    public void UpdateUI()
    {
        title.text = achievement.Title;
        progress.text = $"{achievement.CurrentValue}/{achievement.TargetValue}";
        slider.value = (float)achievement.CurrentValue / achievement.TargetValue;
        rewardButtonText.text = "Get Reward";

        if (achievement.CurrentValue == achievement.TargetValue)
        {
            if (achievement.IsClaimed)
            {
                rewardButtonText.text = "Claimed";
                rewardButton.interactable = false;
            }
            else
            {
                rewardButton.interactable = true;
            }
        }

        // Deletes last rewards
        GameObject[] allChildren = new GameObject[rewardsPanel.transform.childCount];

        for (int i = 0; i < allChildren.Length; i++)
        {
            allChildren[i] = rewardsPanel.transform.GetChild(i).gameObject;
        }

        foreach (GameObject child in allChildren)
        {
            DestroyImmediate(child.gameObject);
        }

        foreach (GameResource reward in achievement.Rewards)
        {
            GameResourceDisplay newRewardDisplay = Instantiate(rewardPrefab, rewardsPanel.transform).GetComponent<GameResourceDisplay>();
            newRewardDisplay.GameResource = reward;
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(transform.GetChild(0).GetComponent<RectTransform>());
    }

    private void OnRewardButtonClick()
    {
        rewardButtonText.text = "Claimed";
        rewardButton.interactable = false;
        achievement.IsClaimed = true;
        RewardManager.instance.RewardPlayer(achievement.Rewards);
    }
}