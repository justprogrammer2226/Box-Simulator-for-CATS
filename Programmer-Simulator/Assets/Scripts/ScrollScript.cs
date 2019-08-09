using System.Collections;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public float speed = -20;
    private float velocity;

    public void Scroll()
    {
        velocity = Random.Range(2.25f, 3f);
        StartCoroutine(ScrollPanel());
    }

    private IEnumerator ScrollPanel()
    {
        while(speed != 0)
        {
            speed = Mathf.MoveTowards(speed, 0, velocity * Time.deltaTime);
            gameObject.transform.Translate(new Vector2(speed, 0) * Time.deltaTime);
            yield return null;
        }
    }
}