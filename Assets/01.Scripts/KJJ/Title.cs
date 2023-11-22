using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var cursor = DOTween.Sequence();

        cursor.Append(transform.DOScale(1.3f, 1.5f));
        cursor.Append(transform.DOScale(1f, 0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
