using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ButtonsManager : MonoBehaviour
{
    public Image imageToScale;
    private bool isZoomOut = false, isFadeOut = true, isFlipOut = false, isFlyOut = false;
    private Vector3 originalPosition = new Vector3(0.61f, 147.3f, 25.4f);
    public void Zoom()
    {
          float zoomVal = 0;
          float targetScale = isZoomOut ? 1.0f : zoomVal;
          imageToScale.transform.DOScale(targetScale, 0.25f);
          isZoomOut = !isZoomOut;
    }

    public void Fade()
   {
          float fadeValue = 1f;
          float targetFade = isFadeOut ? 0f :fadeValue;
          imageToScale.DOFade(targetFade, 1f);
          isFadeOut = !isFadeOut;
   }

   public void Flip()
   {
          float flipValue = 180f;
          float targetFlip = isFlipOut ? 0f : flipValue;
          imageToScale.transform.DORotate(new Vector3(0, targetFlip, 0), 0.25f);
          float targetAlpha = isFlipOut ? 1f : 0f;
          imageToScale.DOFade(targetAlpha, 0.25f); 
          isFlipOut = !isFlipOut;
   }

    public void Fly() //consult sir about this im dying
    {
        float moveDistance = 600f;
        float targetX = isFlyOut ? 1f : moveDistance;
        imageToScale.rectTransform.DOMoveX(targetX, 0.25f);
        isFlyOut = !isFlyOut;
    }

    public void Flash()
   {
          Sequence mySequence = DOTween.Sequence();
          mySequence.Append(imageToScale.DOFade(0f, 0.25f));
          mySequence.Append(imageToScale.DOFade(1f, 0.25f));
          mySequence.Append(imageToScale.DOFade(0f, 0.25f));
          mySequence.Append(imageToScale.DOFade(1f, 0.25f));
   }

   public void Bounce()
    {
        float bounceScale = 1.5f; 
        float bounceDuration = 0.2f; 
        float originalScale = 1.0f;

        imageToScale.transform.DOScale(bounceScale, bounceDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                imageToScale.transform.DOScale(originalScale, bounceDuration)
                    .SetEase(Ease.InQuad)
                    .OnComplete(() =>
                    {
                        imageToScale.transform.DOScale(bounceScale, bounceDuration)
                            .SetEase(Ease.OutQuad)
                            .OnComplete(() =>
                            {
                                imageToScale.transform.DOScale(originalScale, bounceDuration)
                                    .SetEase(Ease.InQuad);
                            });
                    });
            });
    }

}
