using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DOTButton : MonoBehaviour
{
    //public bool cursorOn = false;
    public void OnButtonClick()
    {
        var click = DOTween.Sequence();

        // 스케일이 0.95 -> 1.05 -> 1 로 돌아온다
        click.Append(transform.DOScale(0.95f, 0.1f));
        click.Append(transform.DOScale(1.05f, 0.1f));
        click.Append(transform.DOScale(1f, 0.1f));
    }

    public void EnterButtonCursor()
    {
        var cursor = DOTween.Sequence();

        cursor.Append(transform.DOScale(1.2f, 0.5f));
    }

    public void ExitButtonCursor()
    {
        var cursor = DOTween.Sequence();

        cursor.Append(transform.DOScale(1f, 0.5f));
    }
}
