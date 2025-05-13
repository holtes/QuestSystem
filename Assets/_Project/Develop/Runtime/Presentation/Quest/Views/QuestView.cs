using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening.CustomPlugins;
using DG.Tweening;

public class QuestView : MonoBehaviour
{
    [SerializeField] private TMP_Text _descriptionTxt;
    [SerializeField] private Slider _progressSlider;

    [Header("Настройки анимации")]
    [SerializeField] private float scaleDownFactor = 0.9f;
    [SerializeField] private float scaleDuration = 0.2f;
    [SerializeField] private float colorChangeDuration = 0.3f;
    [SerializeField] private Color _complitionColor = Color.black;
    

    private float _defaultDescriptionScale = 1;

    public void SetDescription(string descriptionText)
    {
        _descriptionTxt.text = descriptionText;
    }

    public void SetProgress(float value)
    {
        _progressSlider.value = value;
    }

    public void CompleteQuest()
    {
        CompletionAnim();
    }

    private void CompletionAnim()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_descriptionTxt.rectTransform.DOScale(_defaultDescriptionScale * scaleDownFactor, scaleDuration))
                .Append(_descriptionTxt.rectTransform.DOScale(_defaultDescriptionScale, scaleDuration));
        
        sequence.Join(DOTween.To(() => _descriptionTxt.color, x => _descriptionTxt.color = x, _complitionColor, colorChangeDuration));
    }
}
