using UnityEngine;

[CreateAssetMenu(fileName = "New Box Item", menuName = "Box Item")]
public class BoxItemData : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    public Sprite Sprite => _sprite;
}
