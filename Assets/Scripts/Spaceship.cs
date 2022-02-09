using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Spaceship : MonoBehaviour
{
    public int StartHealth = 1;

    private HealthCounter _healthUI;

    public int Health { get; private set; }

    private void Start()
    {
        Health = StartHealth;
        _healthUI = FindObjectOfType<HealthCounter>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        --Health;
        _healthUI.DrawHealth(Health);
        Destroy(collision.gameObject);
        /*GameManager.StopGame();
        GetComponent<Rigidbody>().useGravity = true;
        Mover.StopGame();*/
    }

    public void InvokeAnimation(int direction)
    {
        StartCoroutine(Rotate(direction));
    }

    private IEnumerator Rotate(int direction)
    {
        for (int i = 0; i < 15; ++i)
        {
            transform.Rotate(0, 0, direction);
            yield return null;
        }
    }
}
