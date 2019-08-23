using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class BoxItemGenerator
{
    /// <remark> For the script to work correctly, the box should have at least one items group and in each group at least one item.
    /// Otherwise, the method will return null. </remark>
    public static BoxItem GetRandomItemByBox(Box box)
    {
        float totalChanceSum = box.itemsGroups.Select(group => group.chance).Sum();

        float rnd = Random.Range(0, totalChanceSum);
        float currentSum = 0;

        ItemsGroup[] itemsGroups = box.itemsGroups;

        for (int i = 0; i < itemsGroups.Length; i++)
        {
            if (currentSum <= rnd && rnd <= currentSum + itemsGroups[i].chance)
            {
                return itemsGroups[i].boxItems[Random.Range(0, itemsGroups[i].boxItems.Length)];
            }

            currentSum += itemsGroups[i].chance;
        }

        return null;
    }
}
