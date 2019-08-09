﻿using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

class Player : MonoBehaviour
{
    public static Player instance;

    [Header("Data settings")]
    public PlayerData playerData;
    public PlayerLevelData playerLevelData;

    [Header("Game resource settings")]
    public GameObject playerGameResourcePrefab;
    public GameObject playerGameResourcePanel;

    [Header("Player item settings")]
    public GameObject playerItemPrefab;
    public GameObject playerItemPanel;

    [Header("Experience settings")]
    // It is necessary to find a game resource of experience from all other game resources.
    public GameResource expGameResource;
    public Slider expSlider;
    public TextMeshProUGUI expProgress;

    [Header("Player levels settings")]
    public TextMeshProUGUI currentPlayerLevelText;

    [Header("Debug")]
    [SerializeField] private List<PlayerGameResourceDisplay> _playerGameResourceDisplay;

    private void Awake()
    {
        if (instance == null) instance = this;

        // We make a basic check on the correctness of the entered data.
        // This is necessary in order to avoid unnecessary errors immediately.

        foreach (PlayerLevel playerLevel in playerLevelData.PlayerLevels)
        {
            if (playerLevel.Rewards.Select(reward => reward.GameResource).Distinct().Count() != playerLevel.Rewards.Count())
            {
                throw new Exception("Rewards should be of different types.");
            }
        }

        if (playerLevelData.CurrentPlayerLevel > playerLevelData.PlayerLevels.Count)
        {
            throw new Exception("Current player level cannot be greater than number of player levels.");
        }
    }

    private void Start()
    {
        DisplayPlayerGameResource();
        DisplayPlayerItems();
        UpdateUI();
        // We begin to follow the change in player experience.
        // To be able to change the level of the player.
        SubscribeOnChangeExperience();
    }

    private void DisplayPlayerGameResource()
    {
        foreach (PlayerGameResource playerGameResource in playerData.PlayerGameResources.Where(playerGameResource => playerGameResource.GameResource != expGameResource))
        {
            PlayerGameResourceDisplay newPlayerGameResourceDisplay = Instantiate(playerGameResourcePrefab, playerGameResourcePanel.transform).GetComponent<PlayerGameResourceDisplay>();
            newPlayerGameResourceDisplay.playerGameResource = playerGameResource;
            _playerGameResourceDisplay.Add(newPlayerGameResourceDisplay);
        }
    }

    private void DisplayPlayerItems()
    {
        foreach (PlayerItemData playerItemData in playerData.PlayerItemDatas)
        {
            AddPlayerItem(playerItemData);
        }
    }

    private void SubscribeOnChangeExperience()
    {
        PlayerGameResource expPlayerGameResource = playerData.PlayerGameResources.Single(playerGameResource => playerGameResource.GameResource == expGameResource);

        expPlayerGameResource.OnValueChange += (newValue) =>
        {
            if (playerLevelData.CurrentPlayerLevel != playerLevelData.PlayerLevels.Count && newValue >= playerLevelData.PlayerLevels[playerLevelData.CurrentPlayerLevel].TargetExperience)
            {
                // Give user rewards.
                foreach (PlayerGameResource playerGameResource in playerLevelData.PlayerLevels[playerLevelData.CurrentPlayerLevel].Rewards)
                {
                    AdjustGameResource(playerGameResource.GameResource, playerGameResource.Value);
                }

                // Level up and set the current value of the experience.
                int temp = newValue - playerLevelData.PlayerLevels[playerLevelData.CurrentPlayerLevel].TargetExperience;
                playerLevelData.CurrentPlayerLevel++;
                expPlayerGameResource.Value = temp;
            }
        };
    }

    private void UpdateUI()
    {
        foreach (PlayerGameResourceDisplay playerGameResourceDisplay in _playerGameResourceDisplay)
        {
            playerGameResourceDisplay.UpdateUI();
        }

        if (playerLevelData.CurrentPlayerLevel != playerLevelData.PlayerLevels.Count)
        {
            PlayerGameResource expPlayerGameResource = playerData.PlayerGameResources.Single(playerGameResource => playerGameResource.GameResource == expGameResource);

            expSlider.value = (float)expPlayerGameResource.Value / playerLevelData.PlayerLevels[playerLevelData.CurrentPlayerLevel].TargetExperience;
            expProgress.text = $"{expPlayerGameResource.Value}/{playerLevelData.PlayerLevels[playerLevelData.CurrentPlayerLevel].TargetExperience}";
        }
        else
        {
            expSlider.value = 1;
            expProgress.text = "MAX";
        }

        currentPlayerLevelText.text = (playerLevelData.CurrentPlayerLevel + 1).ToString();
    }

    public void AdjustGameResource(GameResource gameResource, int value)
    {
        if (!playerData.PlayerGameResources.Select(playerGameResource => playerGameResource.GameResource).Contains(gameResource))
        {
            throw new Exception("The game resource you want to adjust was not found in the list of game player resources.");
        }

        playerData.PlayerGameResources.Single(playerGameResource => playerGameResource.GameResource == gameResource).Value += value;
        UpdateUI();
    }

    public void AddPlayerItem(PlayerItemData playerItemData)
    {
        PlayerItemDisplay newPlayerItemDisplay = Instantiate(playerItemPrefab, playerItemPanel.transform).GetComponent<PlayerItemDisplay>();
        newPlayerItemDisplay.playerItem = playerItemData;
        newPlayerItemDisplay.UpdateUI();
    }
}