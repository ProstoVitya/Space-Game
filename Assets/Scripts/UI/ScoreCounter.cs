using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class ScoreCounter : MonoBehaviour
{
    [Tooltip("Score is z coordinate of this object ")]
    [SerializeField] Transform _gameFieldTransform;

    private TMP_Text _scoreText;
    private float _scoreCounter;

    private void Start()
    {
        _scoreText = GetComponent<TMP_Text>();
        _scoreCounter = 0;
    }

    private void Update()
    {
        _scoreText.text = _scoreCounter.ToString("0.0");
        _scoreCounter = _gameFieldTransform.position.z;
    }
}
