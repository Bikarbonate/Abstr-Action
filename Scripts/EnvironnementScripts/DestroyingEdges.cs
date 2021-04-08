using UnityEngine;

public class DestroyingEdges : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paintable"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
