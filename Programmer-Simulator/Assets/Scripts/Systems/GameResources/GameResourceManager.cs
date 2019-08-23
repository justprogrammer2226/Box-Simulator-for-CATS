using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class GameResourceManager : MonoBehaviour
{
    [SerializeField] private List<GameResourceData> _gameResources = new List<GameResourceData>();

    private void Awake()
    {
        if (_gameResources.Select(_ => _.Id).Distinct().Count() != _gameResources.Count())
        {
            throw new Exception("Game resources should have of different id.");
        }
    }

    public Sprite GetSpriteByIndex(int id)
    {
        return _gameResources.Where(_ => _.Id == id).Select(_ => _.Sprite).First();
    }
}