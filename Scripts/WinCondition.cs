using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField] Canvas _winCanvas;

    private bool _isWin;

    public bool IsWin
    {
        get => _isWin;
    }

    private void Awake()
    {
        _isWin = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("C'est gagné !");
            _isWin = true;
            _winCanvas.gameObject.SetActive(true);
        }
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
