using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Drop : MonoBehaviour
{
    public GameObject detector;
    Vector3 pos_awal, scale_awal;
    bool on_pos = false;
    public bool space = false;
    bool clearCount = true;
    public GameObject answerFactory;

    // Start is called before the first frame update
    void Start()
    {
        pos_awal = this.transform.position;
        scale_awal = transform.localScale;
    }

    //���콺 �巡��
    private void OnMouseDrag()
    {
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 pos_mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
        transform.position = new Vector3(pos_mouse.x, pos_mouse.y, pos_mouse.z);
        //transform.localScale = new Vector2(0.5f, 0.5f);
    }

    //���콺�� ����(�ѹ� ���߸� ��ġ����)
    private void OnSpaceUp()
    {
        if (on_pos && space)
        {
            // �´� ��ġ�� detecror�� ��ġ�� ����
            if (transform.rotation.z == detector.transform.rotation.z)
            {
                transform.position = detector.transform.position + new Vector3(0, 0, -0.1f);
                transform.localScale = detector.transform.localScale / GameManager.instance.puzzleScale;
                transform.GetComponent<BoxCollider>().enabled = false;
                if (clearCount)
                {
                    GameManager.instance.clearCount++;
                    GameObject answer = Instantiate(answerFactory);
                    answer.transform.position = transform.position;
                    Destroy(answer, 2);
                    clearCount = false;
                }
            }
        }
        else if (!on_pos && space)
        {
            // Ʋ�ȴٸ� ����ġ
            transform.position = pos_awal;
            transform.localScale = scale_awal;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        // ���� ��ġ�� �´ٸ�
        if (collision.gameObject == detector)
        {
            on_pos = true;
        }
        // ���� ��ġ�� Ʋ�ȴٸ�
        else
        {
            on_pos = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        OnSpaceUp();
    }
}
