using UnityEngine;
using System.Collections;

public class EnnemyCollision : MonoBehaviour
{
    [SerializeField] BrushController _brushController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Paintable") || collision.CompareTag("ReusablePaintable") && collision.GetComponent<SpriteRenderer>().color == _brushController.BluePaint)
        {
            Destroy(gameObject);
        }

    }
}
