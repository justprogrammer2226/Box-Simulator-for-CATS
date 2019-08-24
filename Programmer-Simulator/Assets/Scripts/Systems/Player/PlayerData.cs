using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Player Data")]
class PlayerData : ScriptableObject
{
    [SerializeField] private List<GameResource> _gameResources;
    public List<GameResource> GameResources => _gameResources;

    [SerializeField] private List<GameResource> _boxItems;
    public List<GameResource> BoxItems => _boxItems;
}