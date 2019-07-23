using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AchievementHandler : MonoBehaviour
{
    public List<Achievement> achievementList;
    [SerializeField] private List<AchievementDisplay> _achievementDisplayList;
    public GameObject achievementPrefab;
    public GameObject achievementPanel;

    public Button testButton;

    private void Awake()
    {
        // We make a basic check on the correctness of the entered data.
        // This is necessary in order to avoid unnecessary errors immediately.

        if (achievementList.Distinct().Count() != achievementList.Count())
        {
            throw new Exception("ID values are not unique or there are two identical achievements.");
        }

        foreach (Achievement achievement in achievementList)
        {
            if(achievement.CurrentValue > achievement.TargetValue)
            {
                throw new Exception("The current value cannot be greater than the target value.");
            }

            if (achievement.CurrentValue != achievement.TargetValue && achievement.IsClaimed)
            {
                throw new Exception("The achievement is marked as claimed, but the current value and the target value are not equal.");
            }

            if (achievement.Id < 0 || achievement.CurrentValue < 0 || achievement.TargetValue < 0)
            {
                throw new Exception("ID, the current value and the target value can not be negative.");
            }

            if (achievement.Rewards.Select(reward => reward.GameResource).Distinct().Count() != achievement.Rewards.Count())
            {
                throw new Exception("Rewards should be of different types.");
            }
        }
    }

    private void Start()
    {
        testButton.onClick.AddListener(() => AdjustAchievement(0, 1));

        _achievementDisplayList = new List<AchievementDisplay>();
        foreach (Achievement achievement in achievementList)
        {
            AchievementDisplay newAchievementDisplay = Instantiate(achievementPrefab, achievementPanel.transform).GetComponent<AchievementDisplay>();
            newAchievementDisplay.achievement = achievement;
            newAchievementDisplay.UpdateUI();
            _achievementDisplayList.Add(newAchievementDisplay);
        }
    }

    public void AdjustAchievement(int id, int value)
    {
        if (id < 0 || id > achievementList.Count) return;

        if (achievementList[id].TargetValue == achievementList[id].CurrentValue) return;

        if (value <= 0) return;

        achievementList[id].CurrentValue += value;

        if (achievementList[id].CurrentValue >= achievementList[id].TargetValue)
        {
            achievementList[id].CurrentValue = achievementList[id].TargetValue;
            CompleteAchievement(id);
        }

        _achievementDisplayList[id].UpdateUI();
    }

    private void CompleteAchievement(int id)
    {
        Debug.Log("Ачивка кароче палучена типа, бонжурно, возьмите плез награждение своё сударь");
    }
}
