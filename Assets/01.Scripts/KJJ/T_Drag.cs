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
    
    // ���콺 �巡��
    private void OnMouseDrag()
    {
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 pos_mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
        transform.position = new Vector3(pos_mouse.x, pos_mouse.y, pos_mouse.z);
        //transform.localScale = new Vector2(0.5f, 0.5f);
    }

    // ���콺�� ����(�ѹ� ���߸� ��ġ����)
    private void OnMouseUp()
    {
        if(on_pos)
        {
            // �´� ��ġ�� detecror�� ��ġ�� ����
            transform.position = detector.transform.position;
            transform.localScale = new Vector2(0.5f, 0.5f);
        }
        else
        {
            // Ʋ�ȴٸ� ����ġ
            transform.position = pos_awal;
            transform.localScale = scale_awal;
        }
    }

    // ���� ��ġ�� �´ٸ�
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == detector)
        {
            on_pos = true;
        }
    }

    // ���� ��ġ�� Ʋ�ȴٸ�
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
