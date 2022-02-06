using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ValuableResource : MonoBehaviour
{
    [SerializeField] private int _value;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (other.CompareTag("Player"))
            DataHandler.FoundedResouses += _value;         
    }
}
