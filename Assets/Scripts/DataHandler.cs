
using UnityEngine;

public enum Rotation
{
    LEFT, RIGHT, NONE
}

public static class DataHandler
{
    public static bool GameOver { get; private set; }
    public static Rotation ShipRotation = Rotation.NONE;
    public static int FoundedResouses = 0;

    public static void StartGame()
    {
        FoundedResouses = 0;
        GameOver = false;
    }
    public static void StopGame()
    {
        GameOver = true;
        int currMoney = PlayerPrefs.GetInt("Money");
        PlayerPrefs.SetInt("Money", currMoney + FoundedResouses);

        Debug.Log(PlayerPrefs.GetInt("Money"));
    }
}