using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class Player : MonoBehaviour
{
    public static Player instance;
    
    public PlayerData playerData;
    public GameObject playerGameResourcePrefab;
    public GameObject playerGameResourcePanel;

    [SerializeField] private List<PlayerGameResourceDisplay> _playerGameResourceDisplay;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        foreach (PlayerGameResource playerGameResource in playerData.PlayerGameResources)
        {
            PlayerGameResourceDisplay newPlayerGameResourceDisplay = Instantiate(playerGameResourcePrefab, playerGameResourcePanel.transform).GetComponent<PlayerGameResourceDisplay>();
            newPlayerGameResourceDisplay.playerGameResource = playerGameResource;
            newPlayerGameResourceDisplay.InitUpdateUI();
            _playerGameResourceDisplay.Add(newPlayerGameResourceDisplay);
        }
    }

    public void AdjustGameResource(GameResource gameResource, int value)
    {
        if (!playerData.PlayerGameResources.Select(playerGameResource => playerGameResource.GameResource).Contains(gameResource))
        {
            throw new Exception("The game resource you want to adjust was not found in the list of game player resources.");
        }

        _playerGameResourceDisplay.Single(playerGameResourceDisplay => playerGameResourceDisplay.playerGameResource.GameResource == gameResource).value.gameObject.GetComponent<SmoothChangingOfNumber>().TargetValue += (ulong)value;
    }
}
