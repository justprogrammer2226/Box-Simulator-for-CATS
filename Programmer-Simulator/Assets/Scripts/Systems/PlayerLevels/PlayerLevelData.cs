using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Level Data", menuName = "Player Level Data")]
class PlayerLevelData : ScriptableObject
{
    [SerializeField] private int _currentPlayerLevel;
    public int CurrentPlayerLevel
    {
        get => _currentPlayerLevel;
        set => _currentPlayerLevel = value;
    }

    [SerializeField] private List<PlayerLevel> _playerLevels;
    public List<PlayerLevel> PlayerLevels => _playerLevels;
}