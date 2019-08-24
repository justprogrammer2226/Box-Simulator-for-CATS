using System.Collections.Generic;
using UnityEngine;

class RewardManager : MonoBehaviour
{
    public BoxManager boxManager;
    public Player player;

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

        List<GameResource> boxItems = new List<GameResource>();

        for (int i = 0; i < numberOfItems; i++)
        {
            boxItems.Add(GameResourceGenerator.GetRandomResourceByBox(box));
        }

        RewardPlayer(boxItems);
    }

    public void RewardPlayer(List<GameResource> boxItems)
    {
        foreach (GameResource boxItem in boxItems)
        {
            GameResourceType type = GameResourceManager.GetTypeByIndex(boxItem.Id);

            if (type == GameResourceType.Box)
            {
                player.AdjustPlayerBoxItem(boxItem);
                Debug.Log($"Got {boxItem.Value} box item with sprite name {GameResourceManager.GetSpriteByIndex(boxItem.Id)}");
            }
            else if (type == GameResourceType.Player)
            {
                player.AdjustPlayerGameResource(boxItem);
                Debug.Log($"Got {boxItem.Value} game resource with sprite name {GameResourceManager.GetSpriteByIndex(boxItem.Id)}");
            }
        }
    }
}
