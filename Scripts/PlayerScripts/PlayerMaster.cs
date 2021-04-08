using UnityEngine;

public class PlayerMaster : MonoBehaviour
{
    [SerializeField] IntVariable _currentLives;
    [SerializeField] IntVariable _StartLives;

    private bool _isGameOver;

    public bool IsGameOver
    {
        get => _isGameOver;
    }

    private void Awake()
    {
        _currentLives._value = _StartLives._value;
        _isGameOver = false;
    }

    private void Update()
    {
        if(_currentLives._value <= 0)
        {
            _isGameOver = true;
        }

        if(_isGameOver)
        {
            _currentLives._value = _StartLives._value;
        }
    }

    //private void OnApplicationQuit()
    //{
    //    _currentLives._value = _StartLives._value;
    //    _isGameOver = false;
    //}
}
