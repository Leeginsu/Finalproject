using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class T_Drop : MonoBehaviourPun
{
    public GameObject detector;
    Vector3 pos_awal, scale_awal;
    public bool space = false;
    bool clearCount = true;
    public GameObject answerFactory;

    // Start is called before the first frame update
    void Start()
    {
        pos_awal = this.transform.position;
        scale_awal = transform.localScale;
    }


    public void CheckAnswer(int n)
    {
        if (detector.name.Contains(n.ToString()))
        {
            // �´� ��ġ�� detecror�� ��ġ�� ����
            if (transform.rotation.z == detector.transform.rotation.z)
            {
                transform.position = detector.transform.position + new Vector3(0, 0, -0.1f);
                transform.localScale = detector.transform.parent.localScale;
                transform.GetComponent<BoxCollider>().enabled = false;
                if (clearCount)
                {
                    PreGameManager.instance.clearCount++;
                    GameObject answer = Instantiate(answerFactory);
                    answer.transform.position = transform.position;
                    Destroy(answer, 2);
                    clearCount = false;
                }
            }
        }
        else
        {
            // Ʋ�ȴٸ� ����ġ
            transform.position = pos_awal;
            transform.localScale = scale_awal;
        }
    }
}
