using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshCollider), typeof(Rigidbody))]
public class Spaceship : MonoBehaviour
{
    [Header("Characterictics")]
    [Range(1, 5)]
    public int StartHealth = 1;
    [Range(0.5f, 2f)]
    public float ScoreScale = 1f;

    [SerializeField] private float InvulnerabilityTime = 0.5f;

    private float _lastCollisionTime;

    [Header("Sound")]
    [SerializeField] private AudioSource _collisionSound;

    [Header("Effects")]
    [SerializeField] private ParticleSystem _collisionEffect;

     private HealthCounter _healthUI;
    private Transform _transform;

    public int Health { get; private set; }

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        SetCollisionTime();
        Health = StartHealth;
        _healthUI = FindObjectOfType<HealthCounter>();
        GetComponent<MeshCollider>().sharedMesh = GetComponentInChildren<MeshFilter>().mesh;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Time.time - _lastCollisionTime >= InvulnerabilityTime)
        {
            --Health;
            _healthUI.DrawHealth(Health);
            Mover.DecreaseSpeed();
            SetCollisionTime();
        }
        Destroy(collision.gameObject);
        Instantiate(_collisionEffect, _transform.position + Vector3.forward, Quaternion.identity);
        //_collisionSound.Play();
    }

    public void InvokeAnimation(int direction)
    {
        StartCoroutine(Rotate(direction));
    }

    public void SetCollisionTime()
    {
        _lastCollisionTime = Time.time;
    }

    private IEnumerator Rotate(int direction)
    {
        for (int i = 0; i < 15; ++i)
        {
            _transform.Rotate(0, 0, direction);
            yield return null;
        }
    }
}