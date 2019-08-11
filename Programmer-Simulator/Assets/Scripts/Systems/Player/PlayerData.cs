using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Player Data")]
class PlayerData : ScriptableObject
{
    [SerializeField] private List<PlayerGameResource> _playerGameResources;
    public List<PlayerGameResource> PlayerGameResources => _playerGameResources;

    [SerializeField] private List<BoxItemData> _playerItemsData;
    public List<BoxItemData> PlayerItemsData => _playerItemsData;
}