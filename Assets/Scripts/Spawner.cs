using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Spawner : MonoBehaviour
{
    [Header("Objects To Spawn")]
    [Tooltip("Oblects from which obstacles are built")]
    [SerializeField] private GameObject _cube;
    [Tooltip("An object to halp track when to build a new line of obstacles")]
    [SerializeField] private GameObject _platform;
    [Tooltip("Gems that gives money")]
    [SerializeField] private GameObject[] _valuableResources;

    [Header("Objects Color")]
    [Tooltip("The colors that the field will take on during the game")]
    [SerializeField] private Gradient _gradient;
    [Tooltip("Color change rate")]
    [SerializeField] private float _timeBetweenChanges;
    [Range(0f, 1f)] private float _timeProgress;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        BuildBounds();
        BuildLine();
    }

    private void FixedUpdate()
    {
        _timeProgress += Time.deltaTime / _timeBetweenChanges;
        if (_timeProgress >= 1f)
            _timeProgress = 0f;
    }

    private void OnTriggerExit(Collider other)
    {
        BuildBounds();
        BuildLine();
    }

    private void BuildBounds()
    {
        SpawnCube(_transform.GetChild(0), Random.Range(3f, 5f));
        SpawnCube(_transform.GetChild(_transform.childCount - 1), Random.Range(3f, 5f));
    }

    private void BuildLine()
    {
        for (int i = 1; i < _transform.childCount - 1; ++i)
        {
            int random = Random.Range(1, 10);
            SpawnCube(_transform.GetChild(i), random == 9 ? Random.Range(3f, 5f) : Random.Range(0.1f, 1f));
        }
        Instantiate(_platform, _transform.transform.position + new Vector3(0, -1, 0), Quaternion.identity);
    }

    private void SpawnCube(Transform spawner, float height)
    {
        var cubePosition = new Vector3(spawner.position.x, height / 2, spawner.position.z);
        GameObject spawnedCube = Instantiate(_cube, cubePosition, Quaternion.identity);
        spawnedCube.GetComponent<Renderer>().material.color = _gradient.Evaluate(_timeProgress);
        spawnedCube.transform.localScale = new Vector3(1f, height, 1f);

        if (height < 3f && Random.Range(0, 20) == 19)
        {
            int random = Random.Range(0, 20);
            var objectPosition = new Vector3(spawner.position.x, 1.5f, spawner.position.z);
                Instantiate(_valuableResources[random == 19 ? 2 : random > 14 ? 1 : 0],
                    objectPosition, _valuableResources[0].transform.rotation);
        }
    }
}
