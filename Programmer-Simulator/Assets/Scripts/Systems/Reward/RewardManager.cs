using System.Collections.Generic;
using UnityEngine;

class RewardManager : MonoBehaviour
{
    public BoxManager boxManager;
    public Player player;
    public GameResourceManager gameResourceManager;

    public int minNumberOfItems;
    public int maxNumberOfItems;

    private void Awake()
    {
       if(minNumberOfItems > maxNumberOfItems)
        {
            throw new System.Exception("The minimum number of elements cannot be greater than the maximum.");
        }
    }

    public void GetRewardsByBoxIndex(int index)
    {
        int numberOfItems = Random.Range(minNumberOfItems, maxNumberOfItems);
        Box box = boxManager.GetBoxByIndex(index);

        List<BoxItem> boxItems = new List<BoxItem>();

        for (int i = 0; i < numberOfItems; i++)
        {
            boxItems.Add(BoxItemGenerator.GetRandomItemByBox(box));
        }

        RewardPlayer(boxItems);
    }

    public void RewardPlayer(List<BoxItem> boxItems)
    {
        foreach (BoxItem boxItem in boxItems)
        {
            Sprite sprite = gameResourceManager.GetSpriteByIndex(boxItem.GameResourceId);
            Debug.Log($"Got {sprite.name} {boxItem.Value}");
        }
    }
}
