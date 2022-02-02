using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
