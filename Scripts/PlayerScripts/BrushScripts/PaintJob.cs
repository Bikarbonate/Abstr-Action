using UnityEngine;

public class PaintJob : MonoBehaviour
{
    #region Show In Inspector

    [SerializeField] CACRangeCheck _cacRangeCheck;
    [SerializeField] BrushController _brushController;
    [SerializeField] PlayerSFXManager _playerSFXManager;

    #endregion

    #region Public Methods

    public void DoPaint()
    {
        GameObject newPaintableObject = _cacRangeCheck.HitBuffer[0].gameObject;

        if (newPaintableObject.TryGetComponent(out SpriteRenderer spriteRenderer))
        {
            spriteRenderer.color = _brushController.CurrentBrushColor;
        }

        _playerSFXManager.PlaySplashSFX();
    }

    #endregion
}
