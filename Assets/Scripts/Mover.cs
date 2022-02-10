using TMPro;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private static int _direction = 0;
    private static float _frontSpeed = 5f;

    private const float SideSpeed = 5f;
    private const float SpeedIncrease = 1.00005f;

    public TMP_Text speedText;

    private void Start()
    {
        //Move into main menu
        if (!PlayerPrefs.HasKey("Money"))
            PlayerPrefs.SetInt("Money", 0);
        StartMove();
    }

    private void Update()
    {
        transform.position += new Vector3(_direction * SideSpeed * Time.deltaTime,
                    0f, _frontSpeed * Time.deltaTime);
        _frontSpeed *= SpeedIncrease;
        speedText.text = _frontSpeed.ToString();
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

    public static void StopMove()
    {
        _frontSpeed = 0f;
        _direction = 0;
    }

    public static void StartMove()
    {
        _direction = 0;
        _frontSpeed = 5f;
    }

    public static void DecreaseSpeed()
    {
        _frontSpeed *= 0.95f;
        _frontSpeed = Mathf.Clamp(_frontSpeed, 5f, 100f);
    }
}