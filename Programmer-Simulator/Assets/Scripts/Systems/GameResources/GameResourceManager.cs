using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class GameResourceManager : MonoBehaviour
{
    private static GameResourceManager instance;

    [SerializeField] private List<GameResourceData> _gameResources = new List<GameResourceData>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else throw new Exception("Game resource manager already exists");

        if (_gameResources.Select(_ => _.Id).Distinct().Count() != _gameResources.Count())
        {
            throw new Exception("Game resources should have of different id.");
        }
    }

    public static Sprite GetSpriteByIndex(int id)
    {
        return instance.GetSprite(id);
    }

    public Sprite GetSprite(int id)
    {
        return _gameResources.Where(_ => _.Id == id).Select(_ => _.Sprite).Single();
    }

    public static GameResourceType GetTypeByIndex(int id)
    {
        return instance.GetType(id);
    }

    public GameResourceType GetType(int id)
    {
        return _gameResources.Where(_ => _.Id == id).Select(_ => _.Type).Single();
    }

    public static int GetTargetByIndex(int id)
    {
        return instance.GetTarget(id);
    }

    public int GetTarget(int id)
    {
        return _gameResources.Where(_ => _.Id == id).Select(_ => _.TargetValue).Single();
    }
}