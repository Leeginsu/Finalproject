using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTGalleryUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var cursor = DOTween.Sequence();

        cursor.Append(transform.DOScale(0.8f, 1f));
    }
    // Update is called once per frame
    void Update()
    {

    }
}