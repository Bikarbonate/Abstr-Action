using UnityEngine;

public class BrushController : MonoBehaviour
{
    #region Show In Inspector

    [Header("Component Reference")]
    [SerializeField] private CACRangeCheck _cacRangeCheck;

    [Header("Painting")]
    [SerializeField] private PaintJob _paintJob;
    [SerializeField] private Color _redPaint;
    [SerializeField] private Color _bluePaint;


    #endregion

    #region Variables Globales

    private bool _isPainting;
    private bool _isTriggered;
    private Color _currentBrushColor;
    private Color[] _colorArray = new Color[2];
    int _colorIndex = 0;

    #endregion

    #region Private Properties

    public bool IsPainting
    {
        get => _isPainting;
    }

    public bool IsTriggered
    {
        get => _isTriggered;
    }

    public Color CurrentBrushColor
    {
        get => _currentBrushColor;
    }

    public Color RedPaint
    {
        get => _redPaint;
    }

    public Color BluePaint
    {
        get => _bluePaint;
    }

    #endregion

    #region Unity LifeCycle

    private void Awake()
    {
        _colorArray[0] = _redPaint;
        _colorArray[1] = _bluePaint;
    }

    private void Start()
    {
        _currentBrushColor = _redPaint;
    }

    private void Update()
    {
        Paint();
        ColorSwitch();
    }

    #endregion

    #region Private Methods

    private void Paint()
    {
        if (Input.GetAxisRaw("Fire1") > 0 && !_isTriggered)
        {
            _isPainting = true;
            _isTriggered = true;

            if (_cacRangeCheck.ICanPaintThat())
            {
                _paintJob.DoPaint();
            }
        }
        else
        {
            _isPainting = false;
        }

        if (Mathf.Approximately(Input.GetAxisRaw("Fire1"), 0))
        {
            _isTriggered = false;
        }
    }

    private void ColorSwitch() //A optimiser avec une boucle for ?
    {

        if (Input.GetButtonDown("ColorSwap"))
        {
            if (_colorIndex < _colorArray.Length - 1)
            {
                _colorIndex++;
            }
            else if (_colorIndex == _colorArray.Length - 1)
            {
                _colorIndex--;
                if (_colorIndex < 0)
                {
                    _colorIndex = 0;
                }
            }

            _currentBrushColor = _colorArray[_colorIndex];
        }
    }

    

    #endregion
}
