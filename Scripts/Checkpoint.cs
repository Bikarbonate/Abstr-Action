using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] Vector2Variable _spawnPos;
    [SerializeField] Transform _playerTransform;

    private void Start()
    {
        if(_playerTransform.position.x >= transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _spawnPos._value = transform.position;
            gameObject.SetActive(false);
        }
    }
}
