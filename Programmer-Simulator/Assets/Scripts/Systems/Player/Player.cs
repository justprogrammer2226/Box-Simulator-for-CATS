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

    [Header("Player game resource settings")]
    public GameObject playerGameResourcePrefab;
    public GameObject playerGameResourcePanel;

    [Header("Player box item settings")]
    public GameObject playerBoxItemPrefab;
    public GameObject playerBoxItemPanel;

    [Header("Player levels settings")]
    public TextMeshProUGUI currentPlayerLevelText;

    public Action<int> OnMoneyChange;

    private void Awake()
    {
        if (instance == null) instance = this;

        // We make a basic check on the correctness of the entered data.
        // This is necessary in order to avoid unnecessary errors immediately.

        foreach (PlayerLevel playerLevel in playerLevelData.PlayerLevels)
        {
            if (playerLevel.Rewards.Select(reward => reward.GameResourceData).Distinct().Count() != playerLevel.Rewards.Count())
            {
                throw new Exception("Rewards should have of different game resource.");
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

        foreach (GameResource gameResource in playerData.GameResources)
        {
            if(gameResource.GameResourceData.Type != GameResourceType.Player)
            {
                throw new Exception("The player’s game resources must refer to game resources with a type for the player.");
            }
        }

        foreach (GameResource boxItem in playerData.BoxItems)
        {
            if (boxItem.GameResourceData.Type != GameResourceType.Box)
            {
                throw new Exception("The player’s box items must refer to game resources with a type for the box.");
            }
        }

        if (playerData.GameResources.Select(_ => _.GameResourceData).Distinct().Count() != playerData.GameResources.Count())
        {
            throw new Exception("Player game resources should have of different id.");
        }

        if (playerData.GameResources.Select(_ => _.GameResourceData).Distinct().Count() != playerData.GameResources.Count())
        {
            throw new Exception("Player box items should have of different id.");
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
        foreach(GameResource gameResource in playerData.GameResources)
        {
            GameResourceDisplay gameResourceDisplay = Instantiate(playerGameResourcePrefab, playerGameResourcePanel.transform).GetComponent<GameResourceDisplay>();
            gameResourceDisplay.GameResource = gameResource;
        }
    }

    private void DisplayPlayerBoxItems()
    {
        foreach (GameResource boxItem in playerData.BoxItems)
        {
            GameResourceDisplay gameResourceDisplay = Instantiate(playerBoxItemPrefab, playerBoxItemPanel.transform).GetComponent<GameResourceDisplay>();
            gameResourceDisplay.GameResource = boxItem;
        }
    }

    private void UpdateUI()
    {
        currentPlayerLevelText.text = (playerLevelData.CurrentPlayerLevel + 1).ToString();
    }

    public void AdjustPlayerGameResource(GameResource gameResource)
    {
        if (gameResource.GameResourceData.Type == GameResourceType.Player)
        {
            GameResource playerGameResource = playerData.GameResources.Where(_ => _.GameResourceData == gameResource.GameResourceData).SingleOrDefault();
            // Why are we throwing an exception here, and not just adding a game resource, as we do with box elements?
            // Because the player’s game resources are defined from the very beginning and cannot be changed.
            if (playerGameResource == null)
            {
                throw new Exception($"Game resource not found");
            }
            playerGameResource.Value += gameResource.Value;
        }
        else
        {
            throw new Exception($"There was an attempt to add a game resource, but the game resource is for the box.");
        }
    }

    public void AdjustPlayerBoxItem(GameResource boxItem)
    {
        if (boxItem.GameResourceData.Type == GameResourceType.Box)
        {
            GameResource playerBoxItem = playerData.BoxItems.Where(_ => _.GameResourceData == boxItem.GameResourceData).SingleOrDefault();

            if (playerBoxItem == null)
            {
                // We create a new object that will not be associated with the object in the box.
                // If we add an element from the box directly, then the objects in the box and the player will be equal,
                // and because of this, the value will be doubled.
                GameResource newBoxItem = new GameResource(boxItem);
                playerData.BoxItems.Add(newBoxItem);
                GameResourceDisplay gameResourceDisplay = Instantiate(playerBoxItemPrefab, playerBoxItemPanel.transform).GetComponent<GameResourceDisplay>();
                gameResourceDisplay.GameResource = newBoxItem;
            }
            else
            {
                playerBoxItem.Value += boxItem.Value;
                int targetValue = boxItem.GameResourceData.TargetValue;
                if (targetValue < playerBoxItem.Value)
                {
                    playerBoxItem.Value = targetValue;
                }
            }
        }
        else
        {
            throw new Exception($"There was an attempt to add a box element, but the game resource is for the player.");
        }
    }
}
