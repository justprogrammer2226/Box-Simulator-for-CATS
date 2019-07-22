using System.Linq;
using UnityEngine;

[System.Serializable]
public class ItemsGroup
{
    public string name;
    public float chance;
    public GameObject[] items;
}

[System.Serializable]
public class Box
{
    public string name;
    public ItemsGroup[] itemsGroups;
}

public class BoxGenerator : MonoBehaviour
{
    public Box[] boxes;

    /// <summary> Returns a random item from the specified box. summary>
    /// <remark> For the script to work correctly, the box should have at least one items group and in each group at least one item.
    /// Otherwise, the method will return null. </remark>
    public GameObject GetRandomItem(Box box)
    {
        float totalChanceSum = box.itemsGroups.Select(group => group.chance).Sum();

        float rnd = Random.Range(0, totalChanceSum);
        float currentSum = 0;

        ItemsGroup[] itemsGroups = box.itemsGroups;

        for (int i = 0; i < itemsGroups.Length; i++)
        {
            if (currentSum <= rnd && rnd <= currentSum + itemsGroups[i].chance)
            {
                return itemsGroups[i].items[Random.Range(0, itemsGroups[i].items.Length)];
            }

            currentSum += itemsGroups[i].chance;
        }

        return null;
    }

    public Box GetBoxByName(string name)
    {
        return boxes.Single(box => box.name == name);
    }
}
