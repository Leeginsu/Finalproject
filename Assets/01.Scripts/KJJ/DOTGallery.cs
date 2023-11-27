using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTGallery : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        var gallery = DOTween.Sequence();

        gallery.Append(transform.DOMove(target.transform.position, 3f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
