using System.Linq;
using UnityEngine;

[System.Serializable]
public class ItemsGroup
{
    public string name;
    public float chance;
    public BoxItemData[] items;
}

[System.Serializable]
public class Box
{
    public string name;
    public ItemsGroup[] itemsGroups;
}

public class BoxManager : MonoBehaviour
{
    public Box[] boxes;

    public Box GetBoxByName(string name)
    {
        return boxes.Single(box => box.name == name);
    }

    public Box GetBoxByIndex(int index)
    {
        return boxes[index];
    }
}
