using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

class Player : MonoBehaviour
{
    public static Player instance;

    [Header("Data settings")]
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerLevelData playerLevelData;

    [Header("Game resource settings")]
    public GameObject playerGameResourcePrefab;
    public GameObject playerGameResourcePanel;

    [Header("Player item settings")]
    public GameObject playerItemPrefab;
    public GameObject playerItemPanel;

    [Header("Player levels settings")]
    public TextMeshProUGUI currentPlayerLevelText;

    [Header("Debug")]
    [SerializeField] private List<GameResourceDisplay> _playerGameResourceDisplay;

    public Action<int> OnMoneyChange;

    private void Awake()
    {
        if (instance == null) instance = this;

        // We make a basic check on the correctness of the entered data.
        // This is necessary in order to avoid unnecessary errors immediately.

        foreach (PlayerLevel playerLevel in playerLevelData.PlayerLevels)
        {
            if (playerLevel.Rewards.Select(reward => reward.GameResourceId).Distinct().Count() != playerLevel.Rewards.Count())
            {
                throw new Exception("Rewards should have of different sprites.");
            }
        }

        if (playerLevelData.CurrentPlayerLevel > playerLevelData.PlayerLevels.Count)
        {
            throw new Exception("Current player level cannot be greater than number of player levels.");
        }

        if (playerData.BoxItems.Distinct().Count() != playerData.BoxItems.Count())
        {
            throw new Exception("Player box items should have of different game resource.");
        }
    }

    private void Start()
    {
        DisplayPlayerGameResource();
        DisplayPlayerBoxItems();
        UpdateUI();
    }

    private void DisplayPlayerGameResource()
    {
        // TODO DISPLAY
    }

    private void DisplayPlayerBoxItems()
    {        
        // TODO DISPLAY
    }

    private void UpdateUI()
    {
        foreach (GameResourceDisplay gameResourceDisplay in _playerGameResourceDisplay)
        {
            gameResourceDisplay.UpdateUI();
        }

        currentPlayerLevelText.text = (playerLevelData.CurrentPlayerLevel + 1).ToString();
    }
}
