using UnityEngine;

public class CaseScript : MonoBehaviour
{
    public bool openCase = false;
    public GameObject scrollPanel;
    public BoxManager boxGenerator;
    public ScrollScript scrollScript;

    public void CaseButton(string boxName)
    {
        openCase = true;
        gameObject.SetActive(true);
        SimulateBox(boxName, 40);
    }

    private void SimulateBox(string boxName, int numberOfItems)
    {
        for(int i = 0; i < numberOfItems; i++)
        {
            Box box = boxGenerator.GetBoxByName(boxName);
            BoxItemData item = boxGenerator.GetRandomItemByBox(box);
            Instantiate(item, scrollPanel.transform);
        }

        scrollScript.Scroll();
    }
}
