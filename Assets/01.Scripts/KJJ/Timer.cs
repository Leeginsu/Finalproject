using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Timer : MonoBehaviour
{
    bool timerStop = true;

    // Start is called before the first frame update
    private void Update()
    {
        if (timerStop) TimerStart();
    }
    public void TimerStart()
    {
        var cursor = DOTween.Sequence();

        cursor.Append(transform.DOScale(1.2f, 0.5f))
            .Append(transform.DOScale(1.0f, 0.5f).SetLoops(-1));
        timerStop = false;
    }
}
