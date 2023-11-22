using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DOTButton : MonoBehaviour
{
    public Ease ease;
    public GameObject a;
    public GameObject b;
    public void OnButtonClick()
    {
        var click = DOTween.Sequence();

        // �������� 0.95 -> 1.05 -> 1 �� ���ƿ´�
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

    public void BounceStart()
    {
        a.transform.DOMoveY(540, 3).SetEase(ease);
        //               (��ġ, ����ð�)
        //a.transform.DOMoveY(3, 1).SetEase(ease);
    }
}
