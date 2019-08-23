using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Player Data")]
class PlayerData : ScriptableObject
{
    [SerializeField] private List<BoxItem> _boxItems;
    public List<BoxItem> BoxItems => _boxItems;
}