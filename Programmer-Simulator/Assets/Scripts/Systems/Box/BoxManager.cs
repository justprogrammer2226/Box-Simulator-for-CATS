using System.Linq;
using UnityEngine;

[System.Serializable]
public class ItemsGroup
{
    public string name;
    public float chance;
    public BoxItem[] boxItems;
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

    private void Awake()
    {
        foreach(Box box in boxes)
        {
            if (box.itemsGroups.Length == 0)
            {
                throw new System.Exception($"Box with name {box.name} must have at least 1 items group.");
            }

            foreach (ItemsGroup itemsGroup in box.itemsGroups)
            {
                if (itemsGroup.boxItems.Length == 0)
                {
                    throw new System.Exception($"Box with name {box.name} with item group name {itemsGroup.name} must have at least 1 box item.");
                }
            }
        }
    }

    public Box GetBoxByName(string name)
    {
        return boxes.Single(box => box.name == name);
    }

    public Box GetBoxByIndex(int index)
    {
        return boxes[index];
    }
}
