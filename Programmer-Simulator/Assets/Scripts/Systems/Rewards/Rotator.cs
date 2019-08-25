using UnityEngine;

class Rotator : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * 100 * Time.deltaTime);
    }
}
