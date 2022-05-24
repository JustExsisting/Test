using UnityEngine;

public class Triger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
            Destroy(gameObject);
    }
}
