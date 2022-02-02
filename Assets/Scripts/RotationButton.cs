using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RotationButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Rotation _rotation;
    [SerializeField] private UnityEvent _rotationAnimation;
    [SerializeField] private UnityEvent _backAnimation;

    public void OnPointerDown(PointerEventData eventData)
    {
        DataHandler.ShipRotation = _rotation;
        _rotationAnimation.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        DataHandler.ShipRotation = Rotation.NONE;
        _backAnimation.Invoke();
    }
}
