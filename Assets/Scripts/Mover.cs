using UnityEngine;



public class Mover : MonoBehaviour
{
    private static int _direction = 0;
    private static float _frontSpeed = 5f;
    private float _sideSpeed = 5f;

    private void Start()
    {
        DataHandler.StartGame();
        StartGame();
    }

    private void Update()
    {
        transform.position += new Vector3(_direction * _sideSpeed * Time.deltaTime,
                    0f, _frontSpeed * Time.deltaTime);
    }

    public static void RotateShip(Rotation rotation)
    {
        if (rotation == Rotation.LEFT)
        {
            --_direction;
        }
        else if (rotation == Rotation.RIGHT)
        {
            ++_direction;
        }
    }

    public static void StopGame()
    {
        _frontSpeed = 0f;
        _direction = 0;
    }

    public static void StartGame()
    {
        _direction = 0;
        _frontSpeed = 5f;
    }
}
