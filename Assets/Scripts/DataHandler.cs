
public enum Rotation
{
    LEFT, RIGHT, NONE
}

public static class DataHandler
{
    public static bool GameOver { get; private set; }
    public static Rotation ShipRotation = Rotation.NONE;

    public static void StartGame() => GameOver = false;
    public static void StopGame() => GameOver = true;
}
