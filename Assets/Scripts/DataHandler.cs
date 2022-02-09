using UnityEngine;
using System.Collections;

public enum Rotation
{
    LEFT, RIGHT, NONE
}

public class DataHandler
{
    public static Rotation ShipRotation = Rotation.NONE;
    public static int FoundedResouses = 0;
}