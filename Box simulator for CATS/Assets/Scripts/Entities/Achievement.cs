using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement")]
public class Achievement : ScriptableObject
{
    public string title;
    public int id;
    public int targetValue;
    public int currentValue;
    public int reward;
    public bool isClaimed;
}
