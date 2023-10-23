using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Drag : MonoBehaviour
{
    public GameObject detector;
    Vector3 pos_awal, scale_awal;
    bool on_pos = false;

    // Start is called before the first frame update
    void Start()
    {
        pos_awal = this.transform.position;
        scale_awal = transform.localScale;
    }
    
    // 마우스 드래그
    private void OnMouseDrag()
    {
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 pos_mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
        transform.position = new Vector3(pos_mouse.x, pos_mouse.y, pos_mouse.z);
        //transform.localScale = new Vector2(0.5f, 0.5f);
    }

    // 마우스를 떼면(한번 맞추면 위치고정)
    private void OnMouseUp()
    {
        if(on_pos)
        {
            // 맞는 위치면 detecror의 위치에 고정
            transform.position = detector.transform.position;
            transform.localScale = new Vector2(0.5f, 0.5f);
        }
        else
        {
            // 틀렸다면 원위치
            transform.position = pos_awal;
            transform.localScale = scale_awal;
        }
    }

    // 퍼즐 위치가 맞다면
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == detector)
        {
            on_pos = true;
        }
    }

    // 퍼즐 위치가 틀렸다면
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == detector)
        {
            on_pos = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
