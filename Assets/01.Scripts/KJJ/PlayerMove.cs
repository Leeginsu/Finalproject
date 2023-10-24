using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 8f;
    public GameObject puzzle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ű���尪�� �Է¹޴´�.
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //�Է¹��� Ű���尪�� �����Ѵ�.
        Vector3 xy = (x * transform.right) + (y * transform.up);
        transform.position += xy * speed * Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        print(other);
        if(this.transform.childCount == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                other.gameObject.transform.SetParent(this.transform);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.transform.GetChild(0).SetParent(puzzle.transform);
            }
        }
    }
}
