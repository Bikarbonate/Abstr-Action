using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [Header("Component Reference")]
    [SerializeField] private BrushController _brushController;
    [SerializeField] IntVariable _numberOfLives;
    [SerializeField] private WinCondition _winCondition;

    [Header("Palette UI")]
    [SerializeField] private Image _palette;
    [SerializeField] private Color _red;
    [SerializeField] private Color _blue;

    [Header("Text")]
    [SerializeField] TMP_Text _numberOfLivesDisplay;

    [Header("Menues")]
    [SerializeField] Canvas _startMenu;
    [SerializeField] Canvas _pauseMenu;

    //[Header("MenuControl")]
    //[SerializeField] Canvas _transitionCanvas;
    //[SerializeField] Image _panelImage;
    //[SerializeField] TMP_Vertex _transitionText;

    private void Awake()
    {
        _startMenu.gameObject.SetActive(true);
        _pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 0;
    }


    private void Update()
    {
        //Display du nombre de point de vie
        _numberOfLivesDisplay.text = _numberOfLives._value.ToString();

        //Display de la couleur séléctionner sur la palette
        if (_brushController.CurrentBrushColor == _brushController.RedPaint)
        {
            _palette.color = _red;
        }

        if (_brushController.CurrentBrushColor == _brushController.BluePaint)
        {
            _palette.color = _blue;
        }

        //Bouton pause

        if (Input.GetButtonDown("Pause"))
        {
            Time.timeScale = 0;
            _pauseMenu.gameObject.SetActive(true);

            if (Input.GetButtonDown("Pause"))
            {
                _pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void ResetTimeScale()
    {
        Time.timeScale = 1;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    //public void MenuToGameTransition()
    //{
    //    _transitionCanvas.gameObject.SetActive(true);
    //    Color panelAlpha = _panelImage.color;
    //    Color textAlpha = _transitionText.color;
    //    float t = 0.0f;
    //    t += 0.1f * Time.deltaTime;
    //    //_panelImage.color = new Color(0, 0, 0, Mathf.Lerp(0, 100, t));
    //    //_transitionText.color = new Color(0, 0, 0, Mathf.Lerp(0, 100, t));
    //    panelAlpha.a = Mathf.Lerp(0, 100, t);
    //    textAlpha.a = Mathf.Lerp(0, 100, t);
    //    _panelImage.color = panelAlpha;
    //    _transitionText.color = textAlpha;
    //    StartCoroutine(TransitionFade());
    //}

    //IEnumerator TransitionFade()
    //{

    //    yield return new WaitForSeconds(4);


    //}
}
