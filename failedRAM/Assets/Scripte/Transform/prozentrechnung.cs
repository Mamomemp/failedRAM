using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PercentagePositioning : MonoBehaviour
{
    [SerializeField] private float leftPercentage; // Linker Rand in Prozent
    [SerializeField] private float topPercentage; // Oberer Rand in Prozent
    [SerializeField] private float widthPercentage; // Breite in Prozent
    [SerializeField] private float heightPercentage; // Höhe in Prozent

    private RectTransform uiElementRect;
    private RectTransform canvasRect;

    private void OnEnable()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            canvasRect = canvas.GetComponent<RectTransform>();
            uiElementRect = GetComponent<RectTransform>();
            RepositionAndResizeUIElement();
        }
    }

    private void RepositionAndResizeUIElement()
    {
        if (canvasRect != null && uiElementRect != null)
        {
            float canvasWidth = canvasRect.rect.width;
            float canvasHeight = canvasRect.rect.height;

            float posX = canvasWidth * leftPercentage / 100f - canvasWidth / 2f;
            float posY = canvasHeight * topPercentage / 100f - canvasHeight / 2f;

            uiElementRect.anchoredPosition = new Vector2(posX, posY);

            float rectWidth = canvasWidth * widthPercentage / 100f;
            float rectHeight = canvasHeight * heightPercentage / 100f;

            uiElementRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rectWidth);
            uiElementRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rectHeight);
        }
    }
}
