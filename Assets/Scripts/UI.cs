using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _restartMenu;

    private void Update()
    {
        if (DataHandler.GameOver)
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
