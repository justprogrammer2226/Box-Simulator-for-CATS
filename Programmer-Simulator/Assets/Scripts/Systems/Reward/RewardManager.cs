using UnityEngine;

class RewardManager : MonoBehaviour
{
    public BoxItemGenerator boxItemGenerator;
    public BoxManager boxManager;

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

        for(int i = 0; i < numberOfItems; i++)
        {
            // TODO: Display rewards
        }
    }
}
