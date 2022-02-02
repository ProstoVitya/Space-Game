using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject _cube;
    [SerializeField] private GameObject _platform;

    private void Start()
    {
        BuildBounds();
        BuildLine();
    }

    private void OnTriggerExit(Collider other)
    {
        BuildBounds();
        BuildLine();
    }

    private void BuildBounds()
    {
        SpawnCube(transform.GetChild(0), Random.Range(3f, 5f));
        SpawnCube(transform.GetChild(transform.childCount - 1), Random.Range(3f, 5f));
    }

    private void BuildLine()
    {
        for (int i = 1; i < transform.childCount - 1; ++i)
        {
            int random = Random.Range(1, 10);
            SpawnCube(transform.GetChild(i), random == 9 ? Random.Range(3f, 5f) : Random.Range(0.1f, 1f));
        }
        Instantiate(_platform, transform.transform.position + new Vector3(0, -1, 0), Quaternion.identity);
    }

    private void SpawnCube(Transform spawner, float height)
    {
        var cubePosition = new Vector3(spawner.position.x, height / 2, spawner.position.z);
        GameObject spawnedCube = Instantiate(_cube, cubePosition, Quaternion.identity);
        spawnedCube.transform.localScale = new Vector3(1f, height, 1f);
    }
}
