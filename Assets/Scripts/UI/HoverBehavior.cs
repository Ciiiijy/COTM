using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverBehavior : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public RectTransform selected;



    Sequence sq;
    public void OnPointerEnter(PointerEventData eventData)
    {
        sq.Kill();

        //selected.localPosition = transform.localPosition;

        sq =DOTween.Sequence()
            .Append(selected.DOLocalMoveY(transform.localPosition.y,0.2f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
