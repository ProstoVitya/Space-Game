using UnityEngine;



public class Mover : MonoBehaviour
{
    
    private float _frontSpeed = 5f;
    private float _sideSpeed = 5f;

    void Update()
    {
        float xCoordinate = DataHandler.ShipRotation == Rotation.NONE ? 0f :
            DataHandler.ShipRotation == Rotation.LEFT ? -1 : 1;
        transform.position += new Vector3(xCoordinate * _sideSpeed * Time.deltaTime,
                    0f, _frontSpeed * Time.deltaTime);
    }

    public void Rotate(Rotation rotation)
    {
        DataHandler.ShipRotation = rotation;
    }
}
