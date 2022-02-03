using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Transform _gameField;
    private TMP_Text _scoreText;

    private void Start()
    {
        _scoreText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _scoreText.text = _gameField.position.z.ToString("0.0");
    }
}
