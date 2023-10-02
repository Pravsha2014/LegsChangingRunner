using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FinishPanel : MonoBehaviour
{
    private readonly float _appearTime = 1f;
    private readonly float _alphaTargetValue = 0f;
    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        _canvasGroup.DOFade(_alphaTargetValue, _appearTime).SetInverted();
    }
}
