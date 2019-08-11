using UnityEngine;

[System.Serializable]
public class MoneyChanger
{
    [SerializeField] private string _name;
    public string Name => _name;

    [SerializeField] private int _value;
    public int Value => _value;
}
