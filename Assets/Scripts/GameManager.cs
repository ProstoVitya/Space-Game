using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Spaceship _spaceShip;

    public static bool GameOver { get; private set; }

    private void Start()
    {
        DataHandler.FoundedResouses = 0;
        GameOver = false;
    }

    private void EndGame()
    {
        GameOver = true;
        StartCoroutine(WatchAds());
        int currMoney = PlayerPrefs.GetInt("Money");
        PlayerPrefs.SetInt("Money", currMoney + DataHandler.FoundedResouses);

        Debug.Log(PlayerPrefs.GetInt("Money"));
    }

    private void Update()
    {
        if (_spaceShip.Health == 0 && !GameOver)
            EndGame();
    }

    private static IEnumerator WatchAds()
    {
        yield return null;
    }
}
