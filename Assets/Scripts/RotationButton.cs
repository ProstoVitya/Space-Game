using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RotationButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Tooltip("Determines the direction the ship will rotate")]
    [SerializeField] private Rotation _rotation;
    [Tooltip("Choose AnimationInvoke on Moover")]
    [SerializeField] private UnityEvent _rotationAnimation;
    [Tooltip("Choose AnimationInvoke in SpaceShip script")]
    [SerializeField] private UnityEvent _backAnimation;

    public void OnPointerDown(PointerEventData eventData)
    {
        Mover.RotateShip(_rotation);
        _rotationAnimation.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Mover.RotateShip(_rotation == Rotation.LEFT ? Rotation.RIGHT : Rotation.LEFT);
        _backAnimation.Invoke();
    }
}
