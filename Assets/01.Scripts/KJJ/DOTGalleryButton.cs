using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTGalleryButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var cursor = DOTween.Sequence();

        cursor.Append(transform.DOScale(1f, 1f))
            .Append(transform.DOScale(0.7f, 0.5f));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
