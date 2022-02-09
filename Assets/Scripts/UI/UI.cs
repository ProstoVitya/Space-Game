using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [Tooltip("The main screen of the game")]
    [SerializeField] private GameObject _gameScreen;
    [Tooltip("Death screen")]
    [SerializeField] private GameObject _restartMenu;

    private void Update()
    {
        if (GameManager.GameOver)
        {
            _gameScreen.SetActive(false);
            _restartMenu.SetActive(true);
        }
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
