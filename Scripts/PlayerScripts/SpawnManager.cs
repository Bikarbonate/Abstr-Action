using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] PlayerMaster _playerMaster;
    [SerializeField] Vector2Variable _spawnPoint;
    [SerializeField] Transform _playerTransform;
    [SerializeField] private Transform _firstCheckpoint;


    private void Start()
    {
        _spawnPoint._value = _firstCheckpoint.position;
        Respawn();
    }

    private void Update()
    {
        if(_playerMaster.IsGameOver)
        {
            _spawnPoint._value = _firstCheckpoint.position;
        }
    }

    #region Public Methods

    public void Respawn()
    {
        _playerTransform.position = _spawnPoint._value;
    }

    //private void OnApplicationQuit()
    //{
    //    _spawnPoint._value = _firstCheckpoint.position;
    //}

    #endregion
}
