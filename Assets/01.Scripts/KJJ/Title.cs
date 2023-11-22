using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Title : MonoBehaviour
{
    public GameObject startButton;
    // Start is called before the first frame update
    void Start()
    {
        var cursor = DOTween.Sequence();

        cursor.Append(transform.DOScale(1.3f, 1.5f))
        .Join(transform.DORotate(new Vector3(0, 0, 1080), 1.5f, RotateMode.FastBeyond360))
        //cursor.Join(transform.DORotate(new Vector3(0, 360, 0), 2));
        .Append(transform.DOScale(1f, 0.5f))
        .Append(startButton.transform.DOScale(1f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
