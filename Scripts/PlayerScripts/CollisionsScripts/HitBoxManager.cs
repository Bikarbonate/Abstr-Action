using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitBoxManager : MonoBehaviour
{
    [SerializeField] IntVariable _playerCurrentLives;
    [SerializeField] [Range(0,5)] private float _deathDuration;
    [SerializeField] Vector2Variable _spawnPos;
    [SerializeField] Transform _playerTransform;

    private bool _isDead = false;

    public bool IsDead
    {
        get => _isDead;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("CanHurtPlayer") || collision.CompareTag("DeathEdge"))
        {
            _playerCurrentLives._value--;
            _isDead = true;
            Death();
        }
    }

    private void Death()
    {
        StartCoroutine(RespawnTime());
    }

    IEnumerator RespawnTime()
    {
        yield return new WaitForSeconds(_deathDuration);
        _playerTransform.position = _spawnPos._value;
        _isDead = false;

        //Scene scene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(scene.name);
    }
}
